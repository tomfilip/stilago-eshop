(function () {
    'use strict';

    var app = angular.module('app', [
        'ngAnimate',
        'ngSanitize',

        'ui.router',
        'ui.bootstrap',
        'ui.jq',

        'abp'
    ]);

    //Configuration for Angular UI routing.
    app.config([
        '$stateProvider', '$urlRouterProvider',
        function ($stateProvider, $urlRouterProvider) {
            $urlRouterProvider.otherwise('/search/');
            $stateProvider
                .state('home', {
                    url: '/search/:term',
                    templateUrl: '/App/Main/views/home/home.cshtml',
                    menu: 'Home' 
                })
                .state('computerCreate', {
                    url: '/Computer/Create',
                    templateUrl: '/App/Main/views/computer/createEdit.cshtml',
                    menu: 'CreateComputer'
                })
                .state('computerEdit', {
                    url: '/Computer/Edit/:id',
                    templateUrl: '/App/Main/views/computer/createEdit.cshtml',
                    menu: 'EditComputer',
                    hide: true
                })
                .state('computerPreview', {
                    url: '/Computer/Preview/:id',
                    templateUrl: '/App/Main/views/computer/preview.cshtml',
                    menu: 'PreviewComputer',
                    hide: true
                });
        }
    ]);
})();