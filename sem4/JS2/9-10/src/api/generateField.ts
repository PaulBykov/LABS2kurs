import {getSudoku} from "sudoku-gen";

function genRand(min:number, max:number){
    return Math.floor(Math.random() * (max - min + 1)) + min;
}

export function genField(): [number[][], number[][]]{
    const sudoku = getSudoku('medium');
    const strField = sudoku.solution;
    const strFieldArr = strField.split('');

    const numField: number[][] = [];

    if (strFieldArr.length !== 81) {
        throw new Error('Неверный размер массива строк');
    }

    for (let i = 0; i < 9; i++) {
        const row: number[] = [];
        for (let j = 0; j < 9; j++) {
            const index = i * 9 + j;
            const num = parseInt(strFieldArr[index], 10);
            if (isNaN(num) || num < 0 || num > 9) {
                throw new Error('Неверное значение в массиве строк');
            }
            row.push(num);
        }
        numField.push(row);
    }

    const input:number[][] = structuredClone(numField);

    // excluding superfluous
    let i = 0;
    while(i < 81 - 30){
        const index1 = genRand(0, 8);
        const index2 = genRand(0, 8);

        input[index1][index2] = -1;
        i++;
    }

    return [numField, input];
}