function getRandString(len){
    return Array(len)
        .fill(null)
        .map(() => String.fromCharCode(Math.floor(Math.random() * 26) + 97))
        .join('');
}

function getFirstK(k, s){
    let ans = '';
    for(let i = 0; i < k; i++){
        ans += s[i];
    }
    return ans;
}
function recLevenshtein(s1, s2){
    if (s1 === s2) {return 0;}
    if (s1.length === 0) {return s2.length;}
    if (s2.length === 0) {return s1.length;}

    const cost = s1[s1.length - 1] === s2[s2.length - 1] ? 0 : 1;

    return Math.min(
        recLevenshtein(s1.slice(0, -1), s2) + 1, // Удаление
        recLevenshtein(s1, s2.slice(0, -1)) + 1, // Вставка
        recLevenshtein(s1.slice(0, -1), s2.slice(0, -1)) + cost // Замена
    );
}

function levenshteinDP(s1, s2) {
    const m = s1.length + 1;
    const n = s2.length + 1;
    const dp = new Array(m).fill(0).map(() => new Array(n).fill(0));

    for (let i = 0; i < m; i++) {
        dp[i][0] = i;
    }

    for (let j = 0; j < n; j++) {
        dp[0][j] = j;
    }

    for (let i = 1; i < m; i++) {
        for (let j = 1; j < n; j++) {
            const cost = s1[i - 1] === s2[j - 1] ? 0 : 1;

            dp[i][j] = Math.min(
                dp[i - 1][j] + 1, // Удаление
                dp[i][j - 1] + 1, // Вставка
                dp[i - 1][j - 1] + cost // Замена
            );
        }
    }

    return dp[m - 1][n - 1];
}

function task1(){
    const S1 = getRandString(300);
    const S2 = getRandString(200);

    console.log(`S1 = ${S1}`);
    console.log(`S2 = ${S2}`);

    const K = 1/25;

    console.time('REC');
    console.log(recLevenshtein(getFirstK(K * S1.length, S1), getFirstK(K * S2.length, S2)));
    console.timeEnd('REC');
    console.time('DP');
    console.log(levenshteinDP(getFirstK(K * S1.length, S1), getFirstK(K * S2.length, S2)));
    console.timeEnd('DP');
}
task1()


