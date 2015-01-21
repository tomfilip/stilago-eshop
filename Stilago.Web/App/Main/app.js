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
        function($stateProvider, $urlRouterProvider) {
            $urlRouterProvider.otherwise('/');
            $stateProvider
                .state('home', {
                    url: '/',
                    templateUrl: '/App/Main/views/home/home.cshtml',
                    menu: 'Home' //Matches to name of 'Home' menu in StilagoNavigationProvider
                })
                .state('about', {
                    url: '/about',
                    templateUrl: '/App/Main/views/about/about.cshtml',
                    menu: 'About' //Matches to name of 'About' menu in StilagoNavigationProvider
                });
                //.state('search', {
                //    url: '/search',
                //    templateUrl: '/App/Main/views/search/index.cshtml',
                //    menu: 'Search' //Matches to name of 'About' menu in StilagoNavigationProvider
                //}).state('shoppingCart', {
                //    url: '/orders/shopping-cart',
                //    templateUrl: '/App/Main/views/orders/shoppingCart.cshtml',
                //    menu: 'ShoppingCart' //Matches to name of 'About' menu in StilagoNavigationProvider
                //}).state('myOrders', {
                //    url: '/orders/my-orders',
                //    templateUrl: '/App/Main/views/orders/myOrders.cshtml',
                //    menu: 'MyOrders' //Matches to name of 'About' menu in StilagoNavigationProvider
                //});
        }
    ]);
})();