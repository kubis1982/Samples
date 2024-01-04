let url = new URL("http://localhost:3000/contractors");

// firstName
fetch(url)
    .then(response => response.json())
    .then(json => alert(json.items[0].name));

// secondName
async function SecondName() {
    let response = await fetch(url)
    let json = await response.json();
    alert(json.items[1].name);
}

SecondName();