using System;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Windows;
using Retailer_App.Setup;
using Retailer_App.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Retailer_App.Views.Inventories;
using System.Threading.Tasks;

namespace Retailer_App.ViewModels
{
    public class InventoryViewModel : INotifyPropertyChanged
    {
        public InventoryViewModel()
        {
            collection = new ObservableCollection<Inventory>();
            dbconn = new Db_Connection();
            model = new Inventory();

            InsertCommand = new RelayCommand(async () => await InsertDataAsync());
            UpdateCommand = new RelayCommand(async () => await UpdateDataAsync());
            DeleteCommand = new RelayCommand(async () => await DeleteDataAsync());
            SelectCommand = new RelayCommand(async () => await ReadDataAsync());
            ShowCommand = new RelayCommand(async () => await ShowDataAsync());
            SelectCommand.Execute(null);
        }

        public RelayCommand InsertCommand { get; set; }
        public RelayCommand UpdateCommand { get; set; }
        public RelayCommand DeleteCommand { get; set; }
        public RelayCommand SelectCommand { get; set; }
        public RelayCommand ShowCommand { get; set; }

        public ObservableCollection<Inventory> Collection
        {
            get
            {
                return collection;
            }
            set
            {
                collection = value;
                PropertyChanged?.Invoke(this,
                    new PropertyChangedEventArgs(null));
            }
        }

        public Inventory Model
        {
            get
            {
                return model;
            }
            set
            {
                if (value != null)
                {
                    IsChecked = (value.Status == "Active") ? true : false;
                }
                model = value;
                PropertyChanged?.Invoke(this,
                    new PropertyChangedEventArgs(null));
            }
        }

        public bool IsChecked
        {
            get
            {
                return check;
            }
            set
            {
                check = value;
                PropertyChanged?.Invoke(this,
                    new PropertyChangedEventArgs(null));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public event Action OnCallBack;

        private readonly Db_Connection dbconn;
        private ObservableCollection<Inventory> collection;
        private Inventory model;
        private bool check;

        private async Task ReadDataAsync()
        {
            dbconn.OpenConnection();

            await Task.Delay(0);
            var query = "select * from vinventories";
            var sqlcmd = new SqlCommand(query, dbconn.SqlConnect);
            var sqlresult = sqlcmd.ExecuteReader();

            if (sqlresult.HasRows)
            {
                collection.Clear();
                while (sqlresult.Read())
                {
                    collection.Add(new Inventory
                    {
                        Uid = sqlresult[0].ToString(),
                        Users = new User
                        {
                            Name = sqlresult[1].ToString()
                        },
                        LogDate = sqlresult[2].ToString(),
                        Type = sqlresult[3].ToString(),
                        Description = sqlresult[4].ToString(),
                        Status = (sqlresult[5].ToString() == "1") ?
                        "Active" :
                        "Not Active",
                    });
                }
            }
            dbconn.CloseConnection();
            OnCallBack?.Invoke();
        }

        private async Task ShowDataAsync()
        {

            dbconn.OpenConnection();

            await Task.Delay(0);
            var query = $"select * from vinventories WHERE logdate BETWEEN " +
                        $"'{InventoriesView.startDate}' and '{InventoriesView.endDate}'";
            var sqlcmd = new SqlCommand(query, dbconn.SqlConnect);
            var sqlresult = sqlcmd.ExecuteReader();

            if (sqlresult.HasRows)
            {
                collection.Clear();
                while (sqlresult.Read())
                {
                    collection.Add(new Inventory
                    {
                        Uid = sqlresult[0].ToString(),
                        Users = new User
                        {
                            Name = sqlresult[1].ToString()
                        },
                        LogDate = sqlresult[2].ToString(),
                        Type = sqlresult[3].ToString(),
                        Description = sqlresult[4].ToString(),
                        Status = (sqlresult[5].ToString() == "1") ?
                        "Active" :
                        "Not Active",
                    });
                }
            }
            dbconn.CloseConnection();
            OnCallBack?.Invoke();


        }

        private async Task InsertDataAsync()
        {
            if (IsValidating())
            {
                dbconn.OpenConnection();
                var state = check ? "1" : "0";
                var query = $"INSERT INTO inventories VALUES (" +
                            $"'{model.Users}', " +
                            $"'{model.Type}', " +
                            $"'{model.Description}', " +
                            $"'{state}')";
                var sqlcmd = new SqlCommand(query, dbconn.SqlConnect);
                sqlcmd.ExecuteNonQuery();
                dbconn.CloseConnection();
                await ReadDataAsync();
            }
        }

        private async Task UpdateDataAsync()
        {
            if (IsValidating())
            {
                dbconn.OpenConnection();
                var state = check ? "1" : "0";
                var query = $"UPDATE inventories SET " +
                            $"logdate = '{EditorView.EditDate}', " +
                            $"type = '{EditorView.EditType}', " +
                            $"description = '{EditorView.EditDesc}', " +
                            $"WHERE uid = '{EditorView.EditUid}'";
                var sqlcmd = new SqlCommand(query, dbconn.SqlConnect);
                sqlcmd.ExecuteNonQuery();
                dbconn.CloseConnection();
                await ReadDataAsync();
            }
        }

        private async Task DeleteDataAsync()
        {
            if (IsValidating())
            {
                var msg = MessageBox.Show("Apakah Kamu Yakin", "Question",
                    MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (msg == MessageBoxResult.Yes)
                {
                    dbconn.OpenConnection();
                    var query = $"DELETE FROM users WHERE uid = '{model.Uid}'";
                    var sqlcmd = new SqlCommand(query, dbconn.SqlConnect);
                    sqlcmd.ExecuteNonQuery();
                    dbconn.CloseConnection();
                }
                await ReadDataAsync();
            }
        }

        private bool IsValidating2()
        {
            var flag = true;
            if (InventoriesView.startDate == null)
            {
                MessageBox.Show($"Teks dte tidak boleh kosong!!", "Warning",
                                MessageBoxButton.OK,
                                MessageBoxImage.Exclamation);
                flag = false;
            }
            else if (InventoriesView.endDate == null)
            {
                MessageBox.Show($"Teks dt2 tidak boleh kosong!!", "Warning",
                                MessageBoxButton.OK,
                                MessageBoxImage.Exclamation);
                flag = false;
            }
            return flag;
        }

        private bool IsValidating()
        {
            var flag = true;
            if (InventoriesView.startDate == null)
            {
                MessageBox.Show($"Teks dte tidak boleh {InventoriesView.startDate} kosong!!", "Warning",
                                MessageBoxButton.OK,
                                MessageBoxImage.Exclamation);
                flag = false;
            }
            else if (model.Type == null)
            {
                MessageBox.Show("Teks 2 tidak boleh kosong!!", "Warning",
                                MessageBoxButton.OK,
                                MessageBoxImage.Exclamation);
                flag = false;
            }
            else if (model.Status == null)
            {
                MessageBox.Show("Teks 1 tidak boleh kosong!!", "Warning",
                                MessageBoxButton.OK,
                                MessageBoxImage.Exclamation);
                flag = false;
            }
            return flag;
        }
    }
}
