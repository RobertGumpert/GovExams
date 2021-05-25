const host = "http://127.0.0.1:54000";

window.onload = () => {
    let lastSkip = 20;
    const userListContainer = document.getElementsByClassName("user-list-container")[0];
    document.getElementsByClassName("pagination-button")[0].addEventListener('click', () => {
        let request = new XMLHttpRequest();
        const paginationURL = [host, "user/get/list/next/" + lastSkip].join("/");
        request.open(
            "GET",
            paginationURL,
            false
        );
        request.send();
        if (request.status !== 200) {

        } else {
            const json = JSON.parse(request.response);
            lastSkip = json["last_skip"];
            json["users"].forEach((user) => {
                const innerHtml = createHTTML(user);
                console.log(innerHtml);
                userListContainer.insertAdjacentHTML('beforeend', innerHtml);
            });
        }
    });
};

function createHTTML(json) {
    return '<div class="user-container"> ' +
        '<div class="field-container">' +
        ' <div class="field-title">' +
        ' <p> ID: <p> ' +
        '</div> <div class="field-value">' +
        ' <p> ' + json["id"] + ' </p> ' +
        '</div> </div> ' +
        '<div class="field-container"> ' +
        '<div class="field-title"> ' +
        '<p> Имя: <p> ' +
        '</div> ' +
        '<div class="field-value"> ' +
        '<p> ' + json["name"] + ' </p> ' +
        '</div> </div>'
}