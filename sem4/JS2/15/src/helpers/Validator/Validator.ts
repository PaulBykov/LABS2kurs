import { Field } from "../../components/screens/field/fieldClass/Field";
import { generateArray } from "../../api/generateArray";

export class Validator{
    private _field: Field;
    private _validity: boolean[][];
    private _validateController:  (a:boolean[][]) => void;

    public constructor(field: Field, out: boolean[][], controller: (a:boolean[][]) => void) {
        this._field = field;
        this._validity = [...out];
        this._validateController = controller;
    }

    public get HasErrors(){
        return (this._validity.flat()).includes(false);
    };

    public Validate(){
        this.ResetValidity();

        for (let i = 0; i < this._field.Length(); i++) {
            if (!this.isValidRow(i)) {
                this.markRowInvalid(i);
            }
        }

        for (let i = 0; i < this._field.Length(); i++) {
            if (!this.isValidColumn(i)) {
                this.markColumnInvalid(i);
            }
        }

        for(let i = 0; i < this._field.Length(); i++){
            for(let j = 0; j < this._field.Length(); j++){
                if(!this.isValidBlock(i, j)){
                    this.markBlockInvalid(i, j);
                }
            }
        }

        this._validateController([...this._validity]);
    }

    private ResetValidity(){
        const arr = generateArray(9);

        this._validity = arr;
        this._validateController(arr);
    }

    private isValidRow(row: number): boolean {
        return this.isUnique(this._field.GetRow(row));
    }
    private isValidColumn(col: number): boolean {
        return this.isUnique(this._field.GetColumn(col));
    }
    private isValidBlock(row:number, col:number){
        const blockValues: number[] = [];
        const startRow = Math.floor(row / 3) * 3;
        const startCol = Math.floor(col / 3) * 3;

        for (let i = startRow; i < startRow + 3; i++) {
            for (let j = startCol; j < startCol + 3; j++) {
                blockValues.push(this._field.GetCeil(i, j));
            }
        }

        return this.isUnique(blockValues);
    }

    private isUnique(array: number[]): boolean  {
        const seen = new Set<number>();
        for (const num of array) {
            if (num === -1) continue

            if (seen.has(num)) {
                return false;
            }
            seen.add(num);

        }
        return true;
    }


    private markRowInvalid(row: number): void {
        for (let j = 0; j < this._field.GetRow(row).length; j++) {
            this._validity[row][j] = false;
        }
    }
    private markColumnInvalid(col: number): void {
        for (let i = 0; i < this._field.Length(); i++) {
            this._validity[i][col] = false;
        }
    }
    private markBlockInvalid(rowIndex: number, colIndex: number): void {
        const blockValues: number[] = [];
        const startRow = Math.floor(rowIndex / 3) * 3;
        const startCol = Math.floor(colIndex / 3) * 3;

        for (let i = startRow; i < startRow + 3; i++) {
            for (let j = startCol; j < startCol + 3; j++) {
                this._validity[i][j] = false;
            }
        }

    }
}
