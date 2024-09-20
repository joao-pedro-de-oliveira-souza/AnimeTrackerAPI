namespace AnimeTracker.Entities
{
    public class User
    {
        public int Id { get; private set; }

        public string Username { get; private set; }
        public string Email { get; private set; }
        public byte[] PasswordHash { get; private set; }
        public byte[] PasswordSalt { get; private set; }

        public User(int id, string username, string email)
        {
            if (id < 0)
            {
                throw new ArgumentException("Id cannot be negative.");
            }
            Id = id;
            ValidateDomain(username, email);
        }

        public User(string username, string email)
        {
            ValidateDomain(username, email);
        }

        public void ChangePassword(byte[] passwordHash, byte[] passwordSalt)
        {
            if (passwordHash == null || passwordSalt == null)
            {
                throw new ArgumentException("PasswordHash and PasswordSalt cannot be null.");
            }

            PasswordHash = passwordHash;
            PasswordSalt = passwordSalt;
        }

        private void ValidateDomain(string username, string email)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                throw new ArgumentException("Username cannot be null or empty.");
            }

            if (username.Length > 20)
            {
                throw new ArgumentException("Username cannot exceed 20 characters.");
            }

            if (string.IsNullOrWhiteSpace(email))
            {
                throw new ArgumentException("Email cannot be null or empty.");
            }

            if (email.Length > 250)
            {
                throw new ArgumentException("Email cannot exceed 250 characters.");
            }

            Username = username;
            Email = email;
        }
    }
}
