using System;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Блокнотик
{
    public partial class Form1 : Form
    {
        private float currentFontSize = 12f;
        private bool wordWrap = false;
        private bool showStatusBar = true;

        private class TabData
        {
            public Encoding Encoding { get; set; } = Encoding.Default;
            public string FilePath { get; set; }
            public bool IsNewFile { get; set; } = true;
            public bool IsEmpty { get; set; } = true;
        }

        public Form1()
        {
            InitializeComponent();

            // Обработка аргументов командной строки
            string[] args = Environment.GetCommandLineArgs();
            if (args.Length > 1)
            {
                OpenFileInExistingTab(args[1]);
            }
            else
            {
                AddNewTab();
            }

            ApplyLightTheme();

            // Привязка обработчиков меню
            новыйToolStripMenuItem.Click += (s, e) => AddNewTab();
            открытьToolStripMenuItem.Click += ОткрытьToolStripMenuItem_Click;
            сохранитьToolStripMenuItem.Click += СохранитьToolStripMenuItem_Click;
            сохранитьКакToolStripMenuItem.Click += СохранитьКакToolStripMenuItem_Click;
            сохранитьВсеToolStripMenuItem.Click += СохранитьВсеToolStripMenuItem_Click;
            закрытьВкладкуToolStripMenuItem.Click += ЗакрытьВкладкуToolStripMenuItem_Click;
            выйтиToolStripMenuItem.Click += (s, e) => Close();

            отменитьToolStripMenuItem.Click += (s, e) => GetCurrentTextBox()?.Undo();
            вырезатьToolStripMenuItem.Click += (s, e) => GetCurrentTextBox()?.Cut();
            копироватьToolStripMenuItem.Click += (s, e) => GetCurrentTextBox()?.Copy();
            вставитьToolStripMenuItem.Click += (s, e) => GetCurrentTextBox()?.Paste();
            удалитьToolStripMenuItem.Click += (s, e) =>
            {
                var tb = GetCurrentTextBox();
                if (tb != null && tb.SelectionLength > 0) tb.SelectedText = "";
            };

            выбратьВсеToolStripMenuItem.Click += (s, e) => GetCurrentTextBox()?.SelectAll();
            времяИДатаToolStripMenuItem.Click += (s, e) =>
            {
                var textBox = GetCurrentTextBox();
                if (textBox != null)
                {
                    textBox.SelectedText = DateTime.Now.ToString();
                    UpdateTabEmptyStatus(Блокнот.SelectedTab, false);
                }
            };

            увеличитьToolStripMenuItem.Click += (s, e) => ChangeFontSize(2);
            уменьшитьToolStripMenuItem.Click += (s, e) => ChangeFontSize(-2);
            сброситьМасштабToolStripMenuItem.Click += (s, e) =>
            {
                currentFontSize = 12f;
                UpdateFontAllTabs();
            };

            строкаСостоянияToolStripMenuItem.Click += (s, e) =>
            {
                showStatusBar = !showStatusBar;
                statusStrip1.Visible = showStatusBar;
                строкаСостоянияToolStripMenuItem.Checked = showStatusBar;
            };

            светлаяToolStripMenuItem.Click += (s, e) => ApplyLightTheme();
            тёмнаяToolStripMenuItem.Click += (s, e) => ApplyDarkTheme();

            // Обработчики кодировки
            ansiToolStripMenuItem.Click += (s, e) => SetEncoding(Encoding.Default);
            utf16LEToolStripMenuItem.Click += (s, e) => SetEncoding(Encoding.Unicode);
            utf16BEToolStripMenuItem.Click += (s, e) => SetEncoding(Encoding.BigEndianUnicode);
            utf8ToolStripMenuItem.Click += (s, e) => SetEncoding(new UTF8Encoding(false));
            utf8WithBOMToolStripMenuItem.Click += (s, e) => SetEncoding(new UTF8Encoding(true));

            Блокнот.SelectedIndexChanged += (s, e) => UpdateEncodingStatus();

            Блокнот.DrawMode = TabDrawMode.OwnerDrawFixed;
            Блокнот.DrawItem += TabControl1_DrawItem;
            Блокнот.MouseDown += TabControl1_MouseDown;

            var timer = new Timer { Interval = 300 };
            timer.Tick += (s, e) => UpdateStatusBar();
            timer.Start();
        }

        private RichTextBox GetCurrentTextBox()
        {
            return Блокнот.SelectedTab?.Controls.Count > 0
                ? Блокнот.SelectedTab.Controls[0] as RichTextBox
                : null;
        }

        private void SetEncoding(Encoding encoding)
        {
            if (Блокнот.SelectedTab == null) return;

            var tabData = Блокнот.SelectedTab.Tag as TabData ?? new TabData();
            tabData.Encoding = encoding;
            Блокнот.SelectedTab.Tag = tabData;

            UpdateEncodingStatus();
        }

        private void UpdateEncodingStatus()
        {
            if (Блокнот.SelectedTab?.Tag is TabData tabData)
            {
                string encodingName = GetEncodingName(tabData.Encoding);
                encodingLabel.Text = $"Кодировка: {encodingName}";
                UpdateEncodingMenuItems(tabData.Encoding);
            }
        }

        private string GetEncodingName(Encoding encoding)
        {
            if (encoding == Encoding.Default) return "ANSI";
            if (encoding == Encoding.Unicode) return "UTF-16";
            if (encoding == Encoding.BigEndianUnicode) return "UTF-16 BE";
            if (encoding is UTF8Encoding utf8 && utf8.GetPreamble().Length > 0) return "UTF-8 с BOM";
            return "UTF-8";
        }

        private void UpdateEncodingMenuItems(Encoding encoding)
        {
            ansiToolStripMenuItem.Checked = (encoding == Encoding.Default);
            utf16LEToolStripMenuItem.Checked = (encoding == Encoding.Unicode);
            utf16BEToolStripMenuItem.Checked = (encoding == Encoding.BigEndianUnicode);
            utf8ToolStripMenuItem.Checked = (encoding is UTF8Encoding utf8NoBom && utf8NoBom.GetPreamble().Length == 0);
            utf8WithBOMToolStripMenuItem.Checked = (encoding is UTF8Encoding utf8WithBom && utf8WithBom.GetPreamble().Length > 0);
        }

        private void AddNewTab(string title = "Новый документ", string filePath = null)
        {
            var tab = new TabPage(title)
            {
                Tag = new TabData
                {
                    Encoding = Encoding.Default,
                    FilePath = filePath,
                    IsNewFile = string.IsNullOrEmpty(filePath),
                    IsEmpty = true
                }
            };

            var rtb = new RichTextBox
            {
                Dock = DockStyle.Fill,
                Font = new Font("Consolas", currentFontSize),
                WordWrap = wordWrap,
                AcceptsTab = true,
                HideSelection = false
            };

            rtb.TextChanged += (s, e) => UpdateTabEmptyStatus(tab, string.IsNullOrEmpty(rtb.Text));

            tab.Controls.Add(rtb);
            Блокнот.TabPages.Add(tab);
            Блокнот.SelectedTab = tab;
            UpdateEncodingStatus();
        }

        private void UpdateTabEmptyStatus(TabPage tab, bool isEmpty)
        {
            if (tab?.Tag is TabData tabData)
            {
                tabData.IsEmpty = isEmpty;
            }
        }

        private void ОткрытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var dlg = new OpenFileDialog())
            {
                dlg.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    OpenFileInExistingTab(dlg.FileName);
                }
            }
        }

        private void OpenFileInExistingTab(string filePath)
        {
            try
            {
                // Проверяем, есть ли пустая вкладка
                TabPage emptyTab = FindEmptyTab();

                if (emptyTab != null)
                {
                    // Загружаем файл в пустую вкладку
                    LoadFileToTab(emptyTab, filePath);
                    Блокнот.SelectedTab = emptyTab;
                }
                else
                {
                    // Создаем новую вкладку
                    LoadFileToNewTab(filePath);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private TabPage FindEmptyTab()
        {
            foreach (TabPage tab in Блокнот.TabPages)
            {
                if (tab?.Tag is TabData tabData && tabData.IsNewFile && tabData.IsEmpty)
                {
                    var rtb = tab.Controls.Count > 0 ? tab.Controls[0] as RichTextBox : null;
                    if (rtb != null && string.IsNullOrEmpty(rtb.Text))
                    {
                        return tab;
                    }
                }
            }
            return null;
        }

        private void LoadFileToNewTab(string filePath)
        {
            using (var reader = new StreamReader(filePath, true))
            {
                reader.Peek();
                var encoding = reader.CurrentEncoding;
                string text = reader.ReadToEnd();

                AddNewTab(Path.GetFileName(filePath), filePath);
                var rtb = GetCurrentTextBox();
                if (rtb != null)
                {
                    rtb.Text = text;
                    UpdateTabEmptyStatus(Блокнот.SelectedTab, false);
                }

                // Обновляем данные вкладки
                var tabData = Блокнот.SelectedTab.Tag as TabData;
                tabData.Encoding = encoding;
                tabData.FilePath = filePath;
                tabData.IsNewFile = false;
                tabData.IsEmpty = false;

                UpdateEncodingStatus();
            }
        }

        private void LoadFileToTab(TabPage tab, string filePath)
        {
            using (var reader = new StreamReader(filePath, true))
            {
                reader.Peek();
                var encoding = reader.CurrentEncoding;
                string text = reader.ReadToEnd();

                var rtb = tab.Controls[0] as RichTextBox;
                if (rtb != null)
                {
                    rtb.Text = text;
                    UpdateTabEmptyStatus(tab, false);
                }

                // Обновляем данные вкладки
                var tabData = tab.Tag as TabData;
                tabData.Encoding = encoding;
                tabData.FilePath = filePath;
                tabData.IsNewFile = false;
                tabData.IsEmpty = false;
                tab.Text = Path.GetFileName(filePath);

                UpdateEncodingStatus();
            }
        }

        private void СохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!(Блокнот.SelectedTab?.Tag is TabData tabData)) return;
            var rtb = GetCurrentTextBox();
            if (rtb == null) return;

            string filePath = tabData.FilePath;
            if (string.IsNullOrEmpty(filePath))
            {
                СохранитьКакToolStripMenuItem_Click(sender, e);
                return;
            }

            try
            {
                File.WriteAllText(filePath, rtb.Text, tabData.Encoding);
                Блокнот.SelectedTab.Text = Path.GetFileName(filePath);
                tabData.IsNewFile = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void СохранитьКакToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var rtb = GetCurrentTextBox();
            if (rtb == null) return;

            using (SaveFileDialog dlg = new SaveFileDialog())
            {
                dlg.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
                dlg.Title = "Сохранить файл как";

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        var tabData = Блокнот.SelectedTab?.Tag as TabData ?? new TabData();
                        File.WriteAllText(dlg.FileName, rtb.Text, tabData.Encoding);

                        Блокнот.SelectedTab.Tag = new TabData
                        {
                            Encoding = tabData.Encoding,
                            FilePath = dlg.FileName,
                            IsNewFile = false,
                            IsEmpty = string.IsNullOrEmpty(rtb.Text)
                        };

                        Блокнот.SelectedTab.Text = Path.GetFileName(dlg.FileName);
                        this.Text = $"Блокнот - {dlg.FileName}";
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка при сохранении файла: {ex.Message}", "Ошибка",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void СохранитьВсеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (TabPage tab in Блокнот.TabPages)
            {
                Блокнот.SelectedTab = tab;
                СохранитьToolStripMenuItem_Click(sender, e);
            }
        }

        private void ЗакрытьВкладкуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Блокнот.SelectedTab != null)
            {
                Блокнот.TabPages.Remove(Блокнот.SelectedTab);
                if (Блокнот.TabPages.Count == 0)
                {
                    AddNewTab();
                }
            }
        }

        private void ChangeFontSize(float delta)
        {
            float newSize = currentFontSize + delta;
            if (newSize < 6f) newSize = 6f;
            if (newSize > 72f) newSize = 72f;
            currentFontSize = newSize;
            UpdateFontAllTabs();
        }

        private void UpdateFontAllTabs()
        {
            foreach (TabPage tab in Блокнот.TabPages)
            {
                if (tab.Controls.Count > 0 && tab.Controls[0] is RichTextBox rtb)
                {
                    rtb.Font = new Font("Consolas", currentFontSize);
                }
            }
        }

        private void ApplyLightTheme()
        {
            BackColor = Color.White;
            menuStrip1.BackColor = Color.White;
            menuStrip1.ForeColor = Color.Black;
            statusStrip1.BackColor = Color.White;
            statusStrip1.ForeColor = Color.Black;
            foreach (ToolStripMenuItem item in menuStrip1.Items)
                item.ForeColor = Color.Black;
            foreach (TabPage tab in Блокнот.TabPages)
            {
                if (tab.Controls.Count > 0 && tab.Controls[0] is RichTextBox rtb)
                {
                    rtb.BackColor = Color.White;
                    rtb.ForeColor = Color.Black;
                }
            }
        }

        private void ApplyDarkTheme()
        {
            Color back = Color.FromArgb(30, 30, 30);
            Color fore = Color.FromArgb(220, 220, 220);
            BackColor = back;
            menuStrip1.BackColor = back;
            menuStrip1.ForeColor = fore;
            statusStrip1.BackColor = back;
            statusStrip1.ForeColor = fore;
            foreach (ToolStripMenuItem item in menuStrip1.Items)
                item.ForeColor = fore;
            foreach (TabPage tab in Блокнот.TabPages)
            {
                if (tab.Controls.Count > 0 && tab.Controls[0] is RichTextBox rtb)
                {
                    rtb.BackColor = Color.FromArgb(45, 45, 45);
                    rtb.ForeColor = fore;
                }
            }
        }

        private void UpdateStatusBar()
        {
            var rtb = GetCurrentTextBox();
            if (rtb == null)
            {
                statusLabel.Text = "";
                charCountLabel.Text = "Символов: 0";
                return;
            }

            int line = rtb.GetLineFromCharIndex(rtb.SelectionStart) + 1;
            int col = rtb.SelectionStart - rtb.GetFirstCharIndexOfCurrentLine() + 1;
            int length = rtb.TextLength;
            int selLength = rtb.SelectionLength;

            string wrap = wordWrap ? "ВКЛ" : "ВЫКЛ";

            statusLabel.Text = $"Строка: {line}  Столбец: {col}  Выделено: {selLength}   Масштаб: {currentFontSize}pt";
            charCountLabel.Text = $"Символов: {length}";
        }

        private void TabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            TabPage tab = Блокнот.TabPages[e.Index];
            Rectangle tabRect = Блокнот.GetTabRect(e.Index);

            TextRenderer.DrawText(e.Graphics, tab.Text, Блокнот.Font, tabRect, Блокнот.ForeColor, TextFormatFlags.Left);

            int closeSize = 15;
            Rectangle closeRect = new Rectangle(
                tabRect.Right - closeSize - 2,
                tabRect.Top + (tabRect.Height - closeSize) / 2,
                closeSize,
                closeSize);
            e.Graphics.DrawString("×", new Font("Arial", 10, FontStyle.Bold), Brushes.Black, closeRect.Location);
        }

        private void TabControl1_MouseDown(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < Блокнот.TabPages.Count; i++)
            {
                Rectangle tabRect = Блокнот.GetTabRect(i);
                Rectangle closeRect = new Rectangle(
                    tabRect.Right - 15 - 2,
                    tabRect.Top + (tabRect.Height - 15) / 2,
                    15,
                    15);

                if (closeRect.Contains(e.Location))
                {
                    Блокнот.TabPages.RemoveAt(i);
                    if (Блокнот.TabPages.Count == 0)
                    {
                        AddNewTab();
                    }
                    break;
                }
            }
        }

        private void шрифтToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (FontDialog fontDialog = new FontDialog())
            {
                if (Блокнот.SelectedTab != null && Блокнот.SelectedTab.Controls.Count > 0)
                {
                    RichTextBox rtb = Блокнот.SelectedTab.Controls[0] as RichTextBox;
                    if (rtb != null)
                    {
                        fontDialog.Font = rtb.Font;
                        if (fontDialog.ShowDialog() == DialogResult.OK)
                        {
                            int selStart = rtb.SelectionStart;
                            int selLength = rtb.SelectionLength;

                            rtb.SelectAll();
                            string rtf = rtb.Rtf;

                            string oldFontName = rtb.Font.Name;
                            string newFontName = fontDialog.Font.Name;

                            if (oldFontName != newFontName)
                            {
                                rtf = rtf.Replace(oldFontName, newFontName);
                                rtb.Rtf = rtf;
                            }

                            rtb.SelectionFont = fontDialog.Font;
                            rtb.Select(selStart, selLength);
                        }
                    }
                }
            }
        }
    }
}