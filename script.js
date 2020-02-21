function buttonTester(){
    console.log("knapp fungerar");
}

function updateList()
{
  //Hämta alla personer i kö:
  fetch('https://localhost:44352/api/queueitems')
    .then(response => response.json())
    .then(data => buildList(data))
}

function buildList(queueItems)
{
  //Ta bort alla föregående objekt så att listan uppdateras och inte fylls på hela tiden
  document.getElementById("container").innerHTML = "";

  queueItems.forEach(queueItem => {
    //Skapa en div för varje rad
    var newDiv = document.createElement("div");
    newDiv.className = "addedDiv";
    newDiv.textContent = queueItem.name;

    //Skapa en div som håller all viktig data
    var divData = document.createElement("div");
    divData.type = "div";
    divData.value = queueItem.id;
    divData.name = queueItem.title; 

    // lägg till elementen till DOM
    var containerDiv = document.getElementById("container"); 
    containerDiv.appendChild(newDiv);
    newDiv.appendChild(divData);

  });
}

function AddName()
{
    var newName = document.getElementById("skicka").value;

    fetch('https://localhost:44352/api/queueitems',
    {
        headers: { "Content-Type": "application/json; charset=utf-8"},
        method: 'POST',
        body: JSON.stringify(
            {
                name: newName
            })
    })
}