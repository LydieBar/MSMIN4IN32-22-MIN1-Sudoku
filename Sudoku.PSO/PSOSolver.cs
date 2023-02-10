using Sudoku.Shared;

namespace Sudoku.PSO;



public class PSOSolver : ISudokuSolver
{
        public SudokuGrid Solve(SudokuGrid s)
        {   
            int[,] output = new int[9,9];
            //s.Cells --> code pso
            Console.Write("Sudoku be like :");
            int[,] CellsSolver = new int[9,9];
            for(int i=0; i<9; i++){
                Console.Write("\r\n ");
                for(int j=0; j<9; j++){
                    Console.Write(s.Cells[i][j].ToString());
                    CellsSolver[i,j] = s.Cells[i][j];

                }
            }

            const int numOrganisms = 200;
            const int maxEpochs = 5000;
            const int maxRestarts = 40;
            Console.WriteLine($"Setting numOrganisms: {numOrganisms}");
            Console.WriteLine($"Setting maxEpochs: {maxEpochs}");
            Console.WriteLine($"Setting maxRestarts: {maxRestarts}");

            var solver = new SudokuSolver();
            var sudoku = new Sudoku(CellsSolver);
            var solvedSudoku = solver.Solve(sudoku, numOrganisms, maxEpochs, maxRestarts);

            ToStringPSO(solvedSudoku);

            //resolution pso
            //s.Cells = recup tableau
            //return s;
            return s.CloneSudoku();
        }

        public void ToStringPSO(Sudoku s){
            Console.Write("Sudoku be like :");
            int[,] CellsSolver = new int[9,9];
            for(int i=0; i<9; i++){
                Console.Write("\r\n ");
                for(int j=0; j<9; j++){
                    Console.Write(s.CellValues[i,j].ToString());

                }
            }
        }
}

