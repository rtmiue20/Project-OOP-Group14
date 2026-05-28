using System.Collections.Generic;
using QLDH.Data;
using QLDH.Entities;

namespace QLDH.Service
{
    public class AccountManager : BaseManager<Account>
    {
        private const string FileName = "accounts.json";

        public AccountManager()
        {
            items = FileHelper.Load<Account>(FileName);

            // Tạo tài khoản admin mặc định nếu chưa có
            if (items.Count == 0)
            {
                items.Add(new Account("admin", "admin123", "Admin"));
                FileHelper.Save<Account>(FileName, items);
            }
        }

        // 1. C - Create
        public override void Add(Account item)
        {
            base.Add(item);
            FileHelper.Save<Account>(FileName, items);
        }

        // 2. R - Read
        protected override string GetId(Account item)
        {
            return item.Username;
        }

        public override List<Account> GetAll()
        {
            return items;
        }

        // 3. U - Update
        public override void Update(Account item)
        {
            base.Update(item);
            FileHelper.Save<Account>(FileName, items);
        }

        // 4. D - Delete
        public override void Delete(string id)
        {
            base.Delete(id);
            FileHelper.Save<Account>(FileName, items);
        }

        // Search function
        public override List<Account> Search(string keyword)
        {
            List<Account> result = new List<Account>();
            foreach (Account acc in items)
            {
                if (acc.Username.Contains(keyword) || acc.Role.Contains(keyword))
                    result.Add(acc);
            }
            return result;
        }

        // Xác thực đăng nhập
        public Account Login(string username, string password)
        {
            foreach (Account acc in items)
            {
                if (acc.Username == username && acc.Password == password)
                    return acc;
            }
            return null;
        }
    }
}