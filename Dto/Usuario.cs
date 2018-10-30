using System;

namespace Dto
{
    [Serializable]
    public class Usuario
    {
        public Usuario() {
            this.Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
    }
}
