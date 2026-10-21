using System;
using System.Drawing;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;

namespace Блокнотик
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MenuStrip menuStrip1;
        

        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem новыйToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem открытьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьКакToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьВсеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem закрытьВкладкуToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выйтиToolStripMenuItem;

        private System.Windows.Forms.ToolStripMenuItem изменитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem отменитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem вырезатьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem копироватьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem вставитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem удалитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выбратьВсеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem времяИДатаToolStripMenuItem;

        private System.Windows.Forms.ToolStripMenuItem просмотрToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem увеличитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem уменьшитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сброситьМасштабToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem строкаСостоянияToolStripMenuItem;

        private System.Windows.Forms.ToolStripMenuItem настройкиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem светлаяToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem тёмнаяToolStripMenuItem;

        private System.Windows.Forms.ToolStripMenuItem кодировкаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ansiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem utf16LEToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem utf16BEToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem utf8ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem utf8WithBOMToolStripMenuItem;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.новыйToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.открытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьКакToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьВсеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.закрытьВкладкуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выйтиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.изменитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отменитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.вырезатьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.копироватьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.вставитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.удалитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выбратьВсеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.времяИДатаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.шрифтToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.просмотрToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.увеличитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.уменьшитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сброситьМасштабToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.строкаСостоянияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.кодировкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ansiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.utf16LEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.utf16BEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.utf8ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.utf8WithBOMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.настройкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.светлаяToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.тёмнаяToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.encodingLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.charCountLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.Блокнот = new System.Windows.Forms.TabControl();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.изменитьToolStripMenuItem,
            this.просмотрToolStripMenuItem,
            this.кодировкаToolStripMenuItem,
            this.настройкиToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1208, 30);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.новыйToolStripMenuItem,
            this.открытьToolStripMenuItem,
            this.сохранитьToolStripMenuItem,
            this.сохранитьКакToolStripMenuItem,
            this.сохранитьВсеToolStripMenuItem,
            this.закрытьВкладкуToolStripMenuItem,
            this.выйтиToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(59, 26);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // новыйToolStripMenuItem
            // 
            this.новыйToolStripMenuItem.Name = "новыйToolStripMenuItem";
            this.новыйToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.новыйToolStripMenuItem.Text = "Новый";
            // 
            // открытьToolStripMenuItem
            // 
            this.открытьToolStripMenuItem.Name = "открытьToolStripMenuItem";
            this.открытьToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.открытьToolStripMenuItem.Text = "Открыть";
            // 
            // сохранитьToolStripMenuItem
            // 
            this.сохранитьToolStripMenuItem.Name = "сохранитьToolStripMenuItem";
            this.сохранитьToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.сохранитьToolStripMenuItem.Text = "Сохранить";
            // 
            // сохранитьКакToolStripMenuItem
            // 
            this.сохранитьКакToolStripMenuItem.Name = "сохранитьКакToolStripMenuItem";
            this.сохранитьКакToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.сохранитьКакToolStripMenuItem.Text = "Сохранить как";
            // 
            // сохранитьВсеToolStripMenuItem
            // 
            this.сохранитьВсеToolStripMenuItem.Name = "сохранитьВсеToolStripMenuItem";
            this.сохранитьВсеToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.сохранитьВсеToolStripMenuItem.Text = "Сохранить все";
            // 
            // закрытьВкладкуToolStripMenuItem
            // 
            this.закрытьВкладкуToolStripMenuItem.Name = "закрытьВкладкуToolStripMenuItem";
            this.закрытьВкладкуToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.закрытьВкладкуToolStripMenuItem.Text = "Закрыть вкладку";
            // 
            // выйтиToolStripMenuItem
            // 
            this.выйтиToolStripMenuItem.Name = "выйтиToolStripMenuItem";
            this.выйтиToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.выйтиToolStripMenuItem.Text = "Выйти";
            // 
            // изменитьToolStripMenuItem
            // 
            this.изменитьToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.отменитьToolStripMenuItem,
            this.вырезатьToolStripMenuItem,
            this.копироватьToolStripMenuItem,
            this.вставитьToolStripMenuItem,
            this.удалитьToolStripMenuItem,
            this.выбратьВсеToolStripMenuItem,
            this.времяИДатаToolStripMenuItem,
            this.шрифтToolStripMenuItem});
            this.изменитьToolStripMenuItem.Name = "изменитьToolStripMenuItem";
            this.изменитьToolStripMenuItem.Size = new System.Drawing.Size(92, 26);
            this.изменитьToolStripMenuItem.Text = "Изменить";
            // 
            // отменитьToolStripMenuItem
            // 
            this.отменитьToolStripMenuItem.Name = "отменитьToolStripMenuItem";
            this.отменитьToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.отменитьToolStripMenuItem.Text = "Отменить";
            // 
            // вырезатьToolStripMenuItem
            // 
            this.вырезатьToolStripMenuItem.Name = "вырезатьToolStripMenuItem";
            this.вырезатьToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.вырезатьToolStripMenuItem.Text = "Вырезать";
            // 
            // копироватьToolStripMenuItem
            // 
            this.копироватьToolStripMenuItem.Name = "копироватьToolStripMenuItem";
            this.копироватьToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.копироватьToolStripMenuItem.Text = "Копировать";
            // 
            // вставитьToolStripMenuItem
            // 
            this.вставитьToolStripMenuItem.Name = "вставитьToolStripMenuItem";
            this.вставитьToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.вставитьToolStripMenuItem.Text = "Вставить";
            // 
            // удалитьToolStripMenuItem
            // 
            this.удалитьToolStripMenuItem.Name = "удалитьToolStripMenuItem";
            this.удалитьToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.удалитьToolStripMenuItem.Text = "Удалить";
            // 
            // выбратьВсеToolStripMenuItem
            // 
            this.выбратьВсеToolStripMenuItem.Name = "выбратьВсеToolStripMenuItem";
            this.выбратьВсеToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.выбратьВсеToolStripMenuItem.Text = "Выбрать всё";
            // 
            // времяИДатаToolStripMenuItem
            // 
            this.времяИДатаToolStripMenuItem.Name = "времяИДатаToolStripMenuItem";
            this.времяИДатаToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.времяИДатаToolStripMenuItem.Text = "Время и дата";
            // 
            // шрифтToolStripMenuItem
            // 
            this.шрифтToolStripMenuItem.Name = "шрифтToolStripMenuItem";
            this.шрифтToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.шрифтToolStripMenuItem.Text = "Шрифт";
            this.шрифтToolStripMenuItem.Click += new System.EventHandler(this.шрифтToolStripMenuItem_Click);
            // 
            // просмотрToolStripMenuItem
            // 
            this.просмотрToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.увеличитьToolStripMenuItem,
            this.уменьшитьToolStripMenuItem,
            this.сброситьМасштабToolStripMenuItem,
            this.строкаСостоянияToolStripMenuItem});
            this.просмотрToolStripMenuItem.Name = "просмотрToolStripMenuItem";
            this.просмотрToolStripMenuItem.Size = new System.Drawing.Size(94, 26);
            this.просмотрToolStripMenuItem.Text = "Просмотр";
            // 
            // увеличитьToolStripMenuItem
            // 
            this.увеличитьToolStripMenuItem.Name = "увеличитьToolStripMenuItem";
            this.увеличитьToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.увеличитьToolStripMenuItem.Text = "Увеличить";
            // 
            // уменьшитьToolStripMenuItem
            // 
            this.уменьшитьToolStripMenuItem.Name = "уменьшитьToolStripMenuItem";
            this.уменьшитьToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.уменьшитьToolStripMenuItem.Text = "Уменьшить";
            // 
            // сброситьМасштабToolStripMenuItem
            // 
            this.сброситьМасштабToolStripMenuItem.Name = "сброситьМасштабToolStripMenuItem";
            this.сброситьМасштабToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.сброситьМасштабToolStripMenuItem.Text = "Сбросить масштаб";
            // 
            // строкаСостоянияToolStripMenuItem
            // 
            this.строкаСостоянияToolStripMenuItem.Name = "строкаСостоянияToolStripMenuItem";
            this.строкаСостоянияToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.строкаСостоянияToolStripMenuItem.Text = "Строка состояния";
            // 
            // кодировкаToolStripMenuItem
            // 
            this.кодировкаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ansiToolStripMenuItem,
            this.utf16LEToolStripMenuItem,
            this.utf16BEToolStripMenuItem,
            this.utf8ToolStripMenuItem,
            this.utf8WithBOMToolStripMenuItem});
            this.кодировкаToolStripMenuItem.Name = "кодировкаToolStripMenuItem";
            this.кодировкаToolStripMenuItem.Size = new System.Drawing.Size(99, 26);
            this.кодировкаToolStripMenuItem.Text = "Кодировка";
            // 
            // ansiToolStripMenuItem
            // 
            this.ansiToolStripMenuItem.Name = "ansiToolStripMenuItem";
            this.ansiToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.ansiToolStripMenuItem.Text = "ANSI";
            // 
            // utf16LEToolStripMenuItem
            // 
            this.utf16LEToolStripMenuItem.Name = "utf16LEToolStripMenuItem";
            this.utf16LEToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.utf16LEToolStripMenuItem.Text = "UTF-16";
            // 
            // utf16BEToolStripMenuItem
            // 
            this.utf16BEToolStripMenuItem.Name = "utf16BEToolStripMenuItem";
            this.utf16BEToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.utf16BEToolStripMenuItem.Text = "UTF-16 BE";
            // 
            // utf8ToolStripMenuItem
            // 
            this.utf8ToolStripMenuItem.Name = "utf8ToolStripMenuItem";
            this.utf8ToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.utf8ToolStripMenuItem.Text = "UTF-8";
            // 
            // utf8WithBOMToolStripMenuItem
            // 
            this.utf8WithBOMToolStripMenuItem.Name = "utf8WithBOMToolStripMenuItem";
            this.utf8WithBOMToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.utf8WithBOMToolStripMenuItem.Text = "UTF-8 с BOM";
            // 
            // настройкиToolStripMenuItem
            // 
            this.настройкиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.светлаяToolStripMenuItem,
            this.тёмнаяToolStripMenuItem});
            this.настройкиToolStripMenuItem.Name = "настройкиToolStripMenuItem";
            this.настройкиToolStripMenuItem.Size = new System.Drawing.Size(98, 26);
            this.настройкиToolStripMenuItem.Text = "Настройки";
            // 
            // светлаяToolStripMenuItem
            // 
            this.светлаяToolStripMenuItem.Name = "светлаяToolStripMenuItem";
            this.светлаяToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.светлаяToolStripMenuItem.Text = "Светлая";
            // 
            // тёмнаяToolStripMenuItem
            // 
            this.тёмнаяToolStripMenuItem.Name = "тёмнаяToolStripMenuItem";
            this.тёмнаяToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.тёмнаяToolStripMenuItem.Text = "Тёмная";
            // 
            // statusLabel
            // 
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(48, 20);
            this.statusLabel.Text = "Готов";
            // 
            // encodingLabel
            // 
            this.encodingLabel.Name = "encodingLabel";
            this.encodingLabel.Size = new System.Drawing.Size(125, 20);
            this.encodingLabel.Text = "Кодировка: ANSI";
            // 
            // charCountLabel
            // 
            this.charCountLabel.Name = "charCountLabel";
            this.charCountLabel.Size = new System.Drawing.Size(95, 20);
            this.charCountLabel.Text = "Символов: 0";
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel,
            this.encodingLabel,
            this.charCountLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 615);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1208, 26);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // Блокнот
            // 
            this.Блокнот.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Блокнот.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Блокнот.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Блокнот.ItemSize = new System.Drawing.Size(0, 20);
            this.Блокнот.Location = new System.Drawing.Point(0, 30);
            this.Блокнот.Margin = new System.Windows.Forms.Padding(4);
            this.Блокнот.Name = "Блокнот";
            this.Блокнот.Padding = new System.Drawing.Point(20, 5);
            this.Блокнот.SelectedIndex = 0;
            this.Блокнот.Size = new System.Drawing.Size(1208, 585);
            this.Блокнот.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1208, 641);
            this.Controls.Add(this.Блокнот);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Блокнот";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private ToolStripStatusLabel statusLabel;
        private ToolStripStatusLabel encodingLabel;
        private ToolStripStatusLabel charCountLabel;
        private StatusStrip statusStrip1;
        private TabControl Блокнот;
        private ToolStripMenuItem шрифтToolStripMenuItem;
    }
}