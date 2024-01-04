let url = new URL("http://localhost:3000/contractors");

fetch(url)
    .then(response => response.json())
    .then(json => alert(json.items[0].name));

