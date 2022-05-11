using ApiaryDiary.Modules.Users.Core.Exceptions;

namespace ApiaryDiary.Modules.Users.Core.Entities
{
    public class RefreshToken
    {
        public Guid Id { get; private set; }
        public Guid UserId { get; private set; }
        public string Token { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? RevokedAt { get; private set; }
        public DateTime Expires { get; set; }
        public bool IsExpired => DateTime.UtcNow >= Expires;
        public bool Revoked => RevokedAt.HasValue || IsExpired;

        protected RefreshToken()
        {
        }

        public RefreshToken(Guid id, Guid userId, string token, DateTime createdAt, DateTime expires,
            DateTime? revokedAt = null )
        {
            if (string.IsNullOrWhiteSpace(token))
            {
                throw new InvalidTokenException();
            }

            Id = id;
            UserId = userId;
            Token = token;
            CreatedAt = createdAt;
            RevokedAt = revokedAt;
            Expires = expires;
        }

        public void Revoke(DateTime revokedAt)
        {
            if (Revoked)
            {
                throw new InvalidTokenException();
            }

            RevokedAt = revokedAt;
        }
    }
}
