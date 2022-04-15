async function GetRestouran() {
    const response = await fetch("/api/restouran", {
        method: "GET",
        headers: { "Accept": "application/json" }
    });
    if (response.ok === true) {
        const restouran = await response.json();
        let rows = document.querySelector("tbody");
        restouran.forEach(restouran => {
            rows.append(row(restouran));
        });
    }
}

async function GetRestouranById(id) {
    const response = await fetch("/api/restouran/" + id, {
        method: "GET",
        headers: { "Accept": "application/json" }
    });
    if (response.ok === true) {
        const restouran = await response.json();
        const form = document.forms["restouranForm"];
        form.elements["id"].value = restouran.id;
        form.elements["dateandtime"].value = restouran.dateandtime;
        form.elements["number"].value = restouran.number;
        form.elements["fioClient"].value = restouran.fioClient;
        form.elements["phoneClient"].value = restouran.phoneClient;
    }
}

async function CreateRestouran(dateandtime, number, fioClient, phoneClient) {
    const response = await fetch("api/restouran", {
        method: "POST",
        headers: {
            "Accept": "application/json", "Content-Type":
                "application/json"
        },
        body: JSON.stringify({          
            dateandtime: dateandtime,
            number = number,
            fioClient = fioClient,
            phoneClient = phoneClient
        })
    });
    if (response.ok === true) {
        const restouran = await response.json();
        reset();
        document.querySelector("tbody").append(row(restouran));
    }
}

async function EditRestouran(restouranId, dateandtime, number, fioClient, phoneClient) {
    const response = await fetch("/api/restouran/" + restouranId, {
        method: "PUT",
        headers: {
            "Accept": "application/json", "Content-Type":
                "application/json"
        },
        body: JSON.stringify({
            id: parseInt(restouranId, 10),
            dateandtime: dateandtime,
            number: number,
            fioClient: fioClient,
            phoneClient: phoneClient
        })
    });
    if (response.ok === true) {
        const restouran = await response.json();
        reset();
        document.querySelector("tr[data-rowid='" + restouran.id + "']").replaceWith(row(restouran));
    }
}

async function DeleteRestouran(id) {
    const response = await fetch("/api/restouran/" + id, {
        method: "DELETE",
        headers: { "Accept": "application/json" }
    });
    if (response.ok === true) {
        const restouran = await response.json();
        document.querySelector("tr[data-rowid='" + restouran.id + "']").remove();
    }
}

function reset() {
    const form = document.forms["restouranForm"];
    form.reset();
    form.elements["id"].value = 0;
}

function row(restouran) {
    const tr = document.createElement("tr");
    tr.setAttribute("data-rowid", restouran.id);
    const idTd = document.createElement("td");
    idTd.append(restouran.id);
    tr.append(idTd);

    const dateandtimeTd = document.createElement("td");
    dateandtimeTd.append(restouran.dateandtime);
    tr.append(dateandtimeTd);

    const numberTd = document.createElement("td");
    numberTd.append(restouran.number);
    tr.append(numberTd);

    const fioClientTd = document.createElement("td");
    fioClientTd.append(restouran.fioClient);
    tr.append(fioClientTd);

    const phoneClientTd = document.createElement("td");
    phoneClientTd.append(restouran.phoneClient);
    tr.append(phoneClientTd);

    const linksTd = document.createElement("td");
    const editLink = document.createElement("a");

    editLink.setAttribute("data-id", restouran.id);
    editLink.setAttribute("style", "cursor:pointer;padding:15px;");
    editLink.append("Изменить");
    editLink.addEventListener("click", e => {
        e.preventDefault();
        GetRestouranById(restouran.id);
    });

    linksTd.append(editLink);
    const removeLink = document.createElement("a");
    removeLink.setAttribute("data-id", restouran.id);
    removeLink.setAttribute("style", "cursor:pointer;padding:15px;");
    removeLink.append("Удалить");
    removeLink.addEventListener("click", e => {
        e.preventDefault();
        DeleteRestouran(restouran.id);
    });
    linksTd.append(removeLink);
    tr.appendChild(linksTd);
    return tr;
}

function InitialFunction() {
    document.getElementById("reset").click(function (e) {
        e.preventDefault();
        reset();
    })
    document.forms["restouranForm"].addEventListener("submit", e => {
        e.preventDefault();
        const form = document.forms["restouranForm"];
        const id = form.elements["id"].value;
        const dateandtime = form.elements["dateandtime"]

        const number = form.elements["number"].value;
        const fioClient = form.elements["fioClient"].value;
        const phoneClient = form.elements["phoneClient"].value;
        if (id == 0)
            CreateRestouran(dateandtime, number, fioClient, phoneClient);
        else
            EditRestouran(id, dateandtime, number, fioClient, phoneClient);
    });
    GetRestouran();
} 