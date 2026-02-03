using System;
using System.Windows.Forms;
using PasswordManager.Data;
using PasswordManager.Models;

namespace PasswordManager
{
    public class PasswordForm : Form
    {
        private readonly PasswordRepository _repo;

        private TextBox webBox;
        private TextBox userBox;
        private TextBox passBox;
        private Button addButton;
        private Button deleteButton;
        private ListBox listBox;

        public PasswordForm()
        {
            Text = "Password Manager";
            Width = 600;
            Height = 400;

            _repo = new PasswordRepository();

            webBox = new TextBox { Left = 10, Top = 10, Width = 180 };
            userBox = new TextBox { Left = 200, Top = 10, Width = 180 };
            passBox = new TextBox { Left = 390, Top = 10, Width = 180 };

            addButton = new Button { Text = "Add", Left = 10, Top = 40, Width = 80 };
            deleteButton = new Button { Text = "Delete", Left = 100, Top = 40, Width = 80 };

            listBox = new ListBox
            {
                Left = 10,
                Top = 80,
                Width = 560,
                Height = 260
            };

            addButton.Click += Add_Click;
            deleteButton.Click += Delete_Click;

            Controls.Add(webBox);
            Controls.Add(userBox);
            Controls.Add(passBox);
            Controls.Add(addButton);
            Controls.Add(deleteButton);
            Controls.Add(listBox);

            LoadPasswords();
        }

        private void LoadPasswords()
        {
            listBox.Items.Clear();

            foreach (var entry in _repo.GetAll())
            {
                listBox.Items.Add(entry);
            }

        }

        private void Add_Click(object? sender, EventArgs e)
        {
            var entry = new PasswordEntry
            {
                WebDomain = webBox.Text,
                Username = userBox.Text,
                Password = passBox.Text
            };

            _repo.Add(entry);
            LoadPasswords();

            webBox.Clear();
            userBox.Clear();
            passBox.Clear();
        }

        private void Delete_Click(object? sender, EventArgs e)
        {
            if (listBox.SelectedItem is PasswordEntry entry)
            {
                _repo.DeleteById(entry.Id!);
                LoadPasswords();
            }
        }
    }
}
