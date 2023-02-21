﻿using Keras.Applications;
using Numpy;
using Sudoku.Shared;
using System.Diagnostics;

namespace Sudoku.CNN
{
    public class SolverKeras_CNN : ISudokuSolver
    {
        public SudokuGrid Solve(SudokuGrid s)
        {
            string filepath = "saved_model.pb";
            Keras.Models.BaseModel model = Keras.Models.BaseModel.LoadModel(filepath);
            return Simple_solver(s, model);
        }

        private SudokuGrid Simple_solver(SudokuGrid s, Keras.Models.BaseModel model)
        {
            //Conversion de la SudokuGrid en array Numpy pour l'injection dans le CNN
            int[][] SudokuBuffer = new int[9][];
            for (int i = 0;i < 9; i++)
            {
                for (int j = 0; j<9; j++)
                {
                    SudokuBuffer[i][j] = s.Cells[i][j];
                }
            }

            //Prediction du CNN
            var prediction = np.array(SudokuBuffer);
            model.Predict(prediction);
            SudokuGrid sol = new SudokuGrid();
            
            //Reconversion de la solution en SudokuGrid
            for(int i = 0; i < 9; i++)
            {
                for (int j = 0; j<9; j++)
                {
                    sol.Cells[i][j] = (int)prediction[i][j];
                }
            }

            return sol;
        }

        
    }
}
