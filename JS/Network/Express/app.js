const express = require('express');
const app = express();
const port = 3000;

app.get('/', (req, res) => res.send('Hello World!'));

app.get('/contractors', (req, res) => {
    let data1 = { name: "Święty", firstName: "Mariusz", age: 36 }
    let data2 = { name: "Barabara", firstName: "Barbara", age: 18 }
    let result = { count: 2, items: [data1, data2]  }
    res.send(result);
});

app.listen(port, () => console.log(`Example app listening on port ${port}! http://localhost:${port}/`));