using System;
using System.Linq;
using System.Security;

namespace GymManager.BackEnd.Users
{
    public class SignInLogIn
    {
        public void LogIn()
        {
            var usersList = new JsonManager().GetUsers();

            Console.WriteLine("Podaj login");
            var enteredEmail = Console.ReadLine();

            Console.WriteLine("Podaj hasło");
            SecureString encryptedPassword = WriteTextInHideMode();
            string enteredPassword = new System.Net.NetworkCredential(string.Empty, encryptedPassword).Password;

            bool userFound = usersList.Any(user => user.Email == enteredEmail && user.Password == enteredPassword);

            if (userFound)
            {
                var loggedUser = usersList.Single(user => user.Email == enteredEmail && user.Password == enteredPassword);
                User.currentUser = loggedUser;
                Console.Clear();
                Console.WriteLine($"zalogowano pomyślnie jako {enteredEmail}");
            }
            else
            {
                Console.WriteLine("Podałeś nieprawidłowe dane, spróbuj jeszcze raz");
                Console.ReadLine();
                Console.Clear();
                LogIn();
            }
        }
        public void LogOut()
        {
            User.currentUser = null;
        }
        public User SignIn(bool isAdmin)
        {
            var user = new User();
            user.Email = SetEmail(user);
            user.Password = SetPassword(user);
            user.IsAdmin = isAdmin;
            if (user.Email == null || user.Password == null)
            {
                Console.WriteLine("Użytkownik nie został zarejestrowany\n");
            }
            new JsonManager().addUser(user);
            PrintOperationSuccess();
            return user;
        }
        private string SetEmail(User user)
        {
            Console.WriteLine("Podaj swój email:\n");
            var enteredEmail = Console.ReadLine();
            var normalizedEmail = enteredEmail.ToLower();

            if (IsEmailValid(normalizedEmail))
            {
                Console.Clear();
                return normalizedEmail;
            }
            Console.Clear();
            Console.WriteLine("Wprowadzony email jest nieprawidłowy lub jest już zarejestrowany, spróbój ponownie");
            Console.Read();
            SetEmail(user);
            return null;
        }
        public string SetPassword(User user)
        {
            Console.WriteLine("Podaj hasło." +
                              "\nKryteria\n" +
                              "\n*Musi składać się z conajmniej 6 cyfr i nie więcej niż20" +
                              "\n*Conajmniej 1 wielka litera" +
                              "\n*Conajmniej 1 cyfra" +
                              "\n*Zabronione znaki: przecinek,spacja,<,>,',;, \n\n");

            SecureString passwordToSecure1 = WriteTextInHideMode();
            string password1 = new System.Net.NetworkCredential(string.Empty, passwordToSecure1).Password;

            Console.Clear();
            Console.WriteLine("Powtórz wprowadzone hasło");
            SecureString passwordToSecure2 = WriteTextInHideMode();
            string password2 = new System.Net.NetworkCredential(string.Empty, passwordToSecure1).Password;

            if (IsPasswordValid(password1,password2))
            {
                Console.WriteLine($"Pomyślnie zarejestrowano użytkownika {user.Email}\n");
                return password2;
            }
            Console.Clear();
            Console.WriteLine("Wprowadzone hasło nie spełnia kryteriów lub nie wprowadzono 2 takich samych haseł, wciśnij enter i spróbój ponownie");
            Console.ReadLine();
            SetPassword(user);
            return null;
        }
        public bool IsPasswordValid(string password1,string password2)
        {
            //var allowedChars = new Regex("^[a-zA-Z0-9 ]+$");
            var prohibitedChars = " <>',; ".ToCharArray();
            if (password1 == password2 
                && password1.Length >= 6
                && password1.Length <= 20
                && password1.Any(Char.IsUpper)
                && password1.Any(char.IsDigit)
                && !password1.Any(prohibitedCar => prohibitedChars.Contains(prohibitedCar)))
            {
                return true;
            }
            return false;
        }
        public bool IsEmailValid(string userEmail)
        {
            var usersList = new JsonManager().GetUsers();
            bool isAlreadyRegistered = usersList.Any(user => user.Email == userEmail);

            if (userEmail != null && !isAlreadyRegistered)
            {
                try
                {
                    var mailAddress = new System.Net.Mail.MailAddress(userEmail);
                    return mailAddress.Address == userEmail;
                }
                catch
                {
                    return false;
                }
            }
            return false;
        }
        private SecureString WriteTextInHideMode()
        {
            SecureString password = new SecureString();
            ConsoleKeyInfo keyInfo;

            do
            {
                keyInfo = Console.ReadKey(true);
                if (!char.IsControl(keyInfo.KeyChar))
                {
                    password.AppendChar(keyInfo.KeyChar);
                    Console.Write("*");
                }
                else if (keyInfo.Key == ConsoleKey.Backspace && password.Length > 0)
                {
                    password.RemoveAt(password.Length - 1);
                    Console.Write("\b \b");
                }
            } while (keyInfo.Key != ConsoleKey.Enter);

            {
                return password;
            }
        }
        private void PrintOperationSuccess()
        {
            Console.Clear();
            Console.WriteLine("Operacja wykonana pomyślnie, wciśnij dowolny klawisz aby przejść do menu");
            Console.ReadLine();
            Console.Clear();
        }
    }
}