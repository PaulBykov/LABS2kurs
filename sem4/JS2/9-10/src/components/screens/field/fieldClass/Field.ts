import {genField} from "../../../../api/generateField";


export class Field{
    private _hintCount = 0;
    public static readonly _maxHints = 10;

    private readonly _fieldArr:number[][];
    private readonly Updater;
    public readonly solution: number[][];

    public getHintCount(){
        return this._hintCount;
    }

    public constructor(updateState:number, Update : (state: number) => void) {
        [this.solution, this._fieldArr] = genField();
        this.Updater = ()=> Update(++updateState);
    }

    public SetCeil(i:number, j:number, value: number):void{
        this._fieldArr[i][j] = value;
        this.Updater();
    }
    public GetCeil(i:number, j:number):number{
        return this._fieldArr[i][j];
    }

    public GetRow(i:number){
        return this._fieldArr[i];
    }
    public GetColumn(j:number){
        const result = [];

        for(let k = 0; k < this._fieldArr.length; k++){
            result.push(this._fieldArr[k][j])
        }

        return result;
    }

    public Length(){
        return this._fieldArr.length;
    }

    public takeHint(){
        if(this._hintCount >= Field._maxHints){
            return;
        }

        for(let i = 0; i < this.Length(); i++){
            for(let j = 0; j < this.GetRow(i).length; j++){
                if(this.GetCeil(i, j) === -1){
                    this.SetCeil(i, j, this.solution[i][j]);
                    this._hintCount++;
                    return;
                }
            }
        }

    }

}