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

app.listen(port, () => console.log(`Example app listening on port ${port}! http://localhost:${port}/`));