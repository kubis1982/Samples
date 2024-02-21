const express = require('express');
const bodyParser = require('body-parser');
const app = express();
const port = 3001;

app.use(bodyParser.urlencoded({ extended: true }));
app.use(bodyParser.json());
app.use(bodyParser.raw());

app.get('/', (req, res) => res.send('Hello World!'));

let data1 = { name: "Święty", firstName: "Mariusz", age: 36 }
let data2 = { name: "Barabara", firstName: "Barbara", age: 18 }
let array = [data1, data2];

app.get('/contractors', (req, res) => {
    let result = { count: array.length, items: array }
    res.send(result);
});

app.post('/contractors', (req, res) => {
    const data = req.body;

    console.log("Name: ", data.name);
    console.log("Age: ", data.age);
    console.log("FirstName: ", data.firstName);

    array.push(data);

    res.send();
});

app.get('/event-source', (req, res) => {
    res.writeHead(200, {
        'Content-Type': 'text/event-stream',
        'Cache-Control': 'no-cache',
        'Connection': 'keep-alive',
        'Access-Control-Allow-Origin': '*'
    });
    res.flushHeaders();

    let i = 0;
    setInterval(()=>{
        res.write(`id: ${i}\n`);
        res.write(`event: event1\n`);
        res.write(`data: Message -- ${Date.now()}`);
        res.write(`\n\n`);
        i++
    }, 5000)
})

app.listen(port, () => console.log(`Example app listening on port ${port}! http://localhost:${port}/`));