function task1(){
    console.log("\t task1 \t")
    const numbers = [1, 23, 4, 12, 665]
    const [y] = numbers;

    console.log(y);
}



function task2(){
    console.log("\t task2 \t")
    const user = {
        name: 'David',
        age: 19,
    }

    const admin = {
        admin: true,
        ...user
    }

    console.log(admin);
}


function task3(){
    console.log("\t task3 \t")
    const store = {
        state: {
            profilePage: {
                posts: [
                    {id: 1, message: 'Hi', likesCount: 12},
                    {id: 2, message: 'By', likesCount: 1},
                ],
                newPostText: 'About me',
            },
            dialogsPage: {
                dialogs: [
                    {id: 1, name: 'Valera'},
                    {id: 2, name: 'Andrey'},
                    {id: 3, name: 'Sasha'},
                    {id: 4, name: 'Viktor'},
                ],
                messages: [
                    {id: 1, name: 'hi'},
                    {id: 2, name: 'hi hi'},
                    {id: 3, name: 'hi hi hi'},
                ],
            },
            sidebar: [],
        },
    }

    const {
      state: {
        profilePage: { posts },
      },
    } = store;

    posts.forEach((post) => {
        console.log(post.likesCount);
    })

    const {
        state: {
            dialogsPage: { dialogs, messages },
        },
    } = store;

    const onlyEvenIDS = dialogs.filter((elem) => {
        return !(elem.id % 2);
    });

    messages.map((message) => {
        message.message = "Hello user";
    })

    console.log(onlyEvenIDS);
    console.log(messages);
}


function task4(){
    console.log("\t task4 \t")

    let tasks = [
        {id: 1, title: "HTML & CSS", isDone: true},
        {id: 2, title: "JS", isDone: true},
        {id: 3, title: "React", isDone: true},
        {id: 4, title: "REST API", isDone: false},
        {id: 5, title: "GraphQL", isDone: false},
    ]

    tasks = [...tasks, {id: 6, title: "Redux", isDone: false}]
}

function sumValues(x, y, z){
    return x + y + z;
}
function task5(){
    console.log("\t task5 \t")
    const arr = [1, 2, 3]

    console.log(sumValues(...arr))
}

task1();
task2();
task3();
task4();
task5();
