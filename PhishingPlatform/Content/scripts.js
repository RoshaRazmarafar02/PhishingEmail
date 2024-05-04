/*!
    * Start Bootstrap - SB Admin v7.0.7 (https://startbootstrap.com/template/sb-admin)
    * Copyright 2013-2023 Start Bootstrap
    * Licensed under MIT (https://github.com/StartBootstrap/startbootstrap-sb-admin/blob/master/LICENSE)
    */
    // 
// Scripts
// 

window.addEventListener('DOMContentLoaded', event => {

    // Toggle the side navigation
    const sidebarToggle = document.body.querySelector('#sidebarToggle');
    if (sidebarToggle) {
        // Uncomment Below to persist sidebar toggle between refreshes
        // if (localStorage.getItem('sb|sidebar-toggle') === 'true') {
        //     document.body.classList.toggle('sb-sidenav-toggled');
        // }
        sidebarToggle.addEventListener('click', event => {
            event.preventDefault();
            document.body.classList.toggle('sb-sidenav-toggled');
            localStorage.setItem('sb|sidebar-toggle', document.body.classList.contains('sb-sidenav-toggled'));
        });
    }

    var quill = new Quill('#editor', {
        theme: 'snow'
    });

    var form = document.querySelector('form');
    form.onsubmit = function () {
        // Populate hidden form on submit
        var about = document.querySelector('input[name=about]');
        about.value = JSON.stringify(quill.getContents());

        console.log("Submitted", $(form).serialize(), $(form).serializeArray());

        // No back end to actually submit to!
        alert('Open the console to see the submit data!')
        return false;
    };

});

