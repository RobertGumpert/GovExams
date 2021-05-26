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
            //
            var re = new RegExp("ab+c");

            //
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

function validateEmail(email) {
    const re = /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    return re.test(String(email).toLowerCase());
}

function validateTelephone(telephone) {
    const re = /^[+]*[(]{0,1}[0-9]{1,4}[)]{0,1}[-\s\./0-9]*$/;
    return re.test(String(telephone).toLowerCase());
}

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