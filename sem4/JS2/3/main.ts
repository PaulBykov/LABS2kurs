function createPhoneNumber(numbers:number[]):string{
    return "(" + numbers[0] + numbers[1] + numbers[2] + ") " +
            numbers[3] + numbers[4] + numbers[5] + "-" +
            numbers[6] + numbers[7] +numbers[8] +numbers[9];
}

class Challenge{
    static solution(number:number):number{
        let sum :number = 0;

        for(let i :number = 0; i < number; i++){
            if(i % 3 == 0 || i % 5 == 0){
                sum += i;
            }
        }

        return sum;
    }
}

function moveRight(arr:number[], k:number):number[] {
    const arr1 :number[] = [...arr];

    for(let i:number = 0; i < arr1.length; i++){
        arr1[i] = arr[(arr.length - k + i) % arr.length];
    }

    return arr1;
}

function middleArr(arr1: number[], arr2: number[]):number{
    const arr3 :number[] = [...arr1, ...arr2];

    const mid :number = arr3.length / 2;

    if(Math.floor(mid) == Math.ceil(mid)){
        return (arr3[mid] + arr3[mid - 1]) / 2;
    }
    else{
        return arr3[Math.floor(mid)];
    }
}
