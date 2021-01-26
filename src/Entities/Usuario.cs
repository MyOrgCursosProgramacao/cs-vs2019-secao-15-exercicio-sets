using System;

namespace src.Entities
{
    abstract class Usuario : IComparable
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }

        protected Usuario()
        {
        }

        public Usuario(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        public void SetNome(string nome)
        {
            Nome = nome;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Usuario))
            {
                return false;
            }

            Usuario outro = obj as Usuario;

            return Id.Equals(outro.Id);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public override string ToString()
        {
            return Id
                + ", "
                + Nome;
        }

        public int CompareTo(object obj)
        {
            if(!(obj is Usuario))
            {
                throw new ArgumentException("O argumento não é do tipo Usuario");
            }
            Usuario outro = obj as Usuario;
            return Id.CompareTo(outro.Id);
        }
    }
}
