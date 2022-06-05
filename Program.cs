using System;

namespace ChessBit
{
    internal class Program
    {
        static int[] b = new int[256];
        static void Main(string[] args)
        {
            FillBits();
            var res = KnightMoves(60);
            Console.WriteLine(res);
            Console.WriteLine(CountBits2(res));
        }

        static ulong KingMoves(int position)
        {
            ulong K = 1UL << position;
            ulong KnoA = 18374403900871474942 & K;
            ulong KnoH = 9187201950435737471 & K;

            ulong moves =
                (KnoA << 7) | (K << 8) | (KnoH << 9) |
                (KnoA >> 1) |            (KnoH << 1) |
                (KnoA >> 9) | (K >> 8) | (KnoH >> 7);

            return moves;
        }
        static ulong KnightMoves(int position)
        {
            ulong K = 1UL << position;
            ulong KnoA = 18374403900871474942 & K;
            ulong KnoH = 9187201950435737471 & K;
            ulong KnoG = 4557430888798830399 & K;
            ulong KnoB = 18229723555195321596 & K;


            ulong moves =
                (KnoA << 15)  | (KnoH << 17) |
                (KnoB << 6)   | (KnoG << 10) |
                (KnoB >> 10)  | (KnoG >> 6)  |
                (KnoA >> 17)  | (KnoH >> 15);

            return moves;
        }
        static int CountBits(ulong mask)
        {
            int bits = 0;
            while(mask > 0)
            {
                bits++;
                mask &= mask - 1;
            }
            return bits;
        }
        static void FillBits()
        {
            for(int i = 0; i <= 255; i++)
            {
                b[i] = CountBits((ulong)i);
            }
        }
        static int CountBits2(ulong mask)
        {
            int bits = 0;
            while (mask > 0)
            {
                bits += b[mask & 255];
                mask >>= 8;
            }
            return bits;
        }
    }
}
