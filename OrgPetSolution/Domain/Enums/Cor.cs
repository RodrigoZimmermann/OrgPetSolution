using System;

namespace Domain.Enums
{
    [Flags]
    public enum Cor
    {
        Marrom = 1,
        Preto = 2,
        Branco = 4,
        Caramelo = 8,
        Amarelo = 16,
        Mix = 32
    }
}
