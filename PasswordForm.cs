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


            // Labels for input boxes

            // Move everything down and space vertically to avoid overlap
            int startY = 40;
            int verticalSpacing = 35;

            var webLabel = new Label { Text = "Web Domain:", Left = 10, Top = startY, Width = 180 };
            var webBoxY = startY + 20;
            webBox = new TextBox { Left = 10, Top = webBoxY, Width = 180, PlaceholderText = "Enter web domain" };

            var userLabel = new Label { Text = "Username:", Left = 10, Top = webBoxY + verticalSpacing, Width = 180 };
            var userBoxY = webBoxY + verticalSpacing + 20;
            userBox = new TextBox { Left = 10, Top = userBoxY, Width = 180, PlaceholderText = "Enter username" };

            var passLabel = new Label { Text = "Password:", Left = 10, Top = userBoxY + verticalSpacing, Width = 180 };
            var passBoxY = userBoxY + verticalSpacing + 20;
            passBox = new TextBox { Left = 10, Top = passBoxY, Width = 180, PlaceholderText = "Enter password" };

            addButton = new Button { Text = "Add", Left = 10, Top = passBoxY + verticalSpacing, Width = 80 };
            deleteButton = new Button { Text = "Delete", Left = 100, Top = passBoxY + verticalSpacing, Width = 80 };

            var outputLabelY = passBoxY + verticalSpacing + 40;
            var outputLabel = new Label { Text = "Saved Entries:", Left = 10, Top = outputLabelY, Width = 180 };

            listBox = new ListBox
            {
                Left = 10,
                Top = outputLabelY + 20,
                Width = 560,
                Height = 200
            };

            addButton.Click += Add_Click;
            deleteButton.Click += Delete_Click;

            Controls.Add(webLabel);
            Controls.Add(webBox);
            Controls.Add(userLabel);
            Controls.Add(userBox);
            Controls.Add(passLabel);
            Controls.Add(passBox);
            Controls.Add(addButton);
            Controls.Add(deleteButton);
            Controls.Add(outputLabel);
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
