using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShop.CSharpCode
{
    public class User
    {
        public string Email { get; private set; }
        public string Password { get; private set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public bool isActive { get; set; }
        public DateTime UpdateAt { get; set; }
        public decimal Funds { get; private set; }

        public User(string email, string password)
        {
            setEmail(email);
            setPassword(password);
        }

        public void setEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new Exception("Email's incorrect.");
            }
            this.Email = email;
            Update();
        }

        public void setPassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                throw new Exception("Password's incorrect.");
            }
            this.Password = password;
            Update();
        }

        private void Update()
        {
            UpdateAt = DateTime.UtcNow;
        }

        public void setAge(int age)
        {
            if (age < 13)
            {
                throw new Exception("Age must be greater or equal 13.");
            }
            this.Age = age;
            Update();
        }

        public void Activate()
        {
            if (isActive)
            {
                return;
            }
            isActive = true;
            Update();
        }
        public void Deactivate()
        {
            if (!isActive)
            {
                return;
            }
            isActive = false;
            Update();
        }

        public void PurchaseOrder(Order order)
        {
            if (!isActive)
            {
                throw new Exception("Only active users can purchase orders!");
            }
            decimal orderPrice = order.TotalPrice;
            if(Funds - orderPrice < 0)
            {
                throw new Exception("You don't have enuogh money!");
            }

            order.Purchase();
            Funds -= orderPrice;
            Update();
        }

        public void IncreaseFounds(decimal funds)
        {
            if(funds <= 0)
            {
                throw new Exception("Founds must be greater than 0.");
            }
            Funds += funds;
            Update();
        }

    }
}