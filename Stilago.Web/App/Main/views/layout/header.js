(function () {
    var controllerId = 'app.views.layout.header';
    angular.module('app').controller(controllerId, [
        '$rootScope', '$stateParams', '$state', '$timeout', 'abp.services.app.search', function ($rootScope, $stateParams, $state, $timeout, searchService) {
            var vm = this;

            vm.languages = abp.localization.languages;
            vm.currentLanguage = abp.localization.currentLanguage;

            vm.menu = abp.nav.menus.MainMenu;
            vm.currentMenuName = $state.current.menu;

            $rootScope.searchTerm = $stateParams.term;

            function KeyUpEvent(event) {
                if (event.keyCode == 13 || $(this).val() == "") {
                    $("#beginSearch").click();
                }   
            }

            $("#searchInput").keyup(KeyUpEvent);

            $("#searchInput").autocomplete({
                source: function (request, response) {
                    searchService.autocomplete({
                        searchTerm: request.term,
                        brandId: null,
                        sortBy: 0,
                        sortDirection: 0
                    }).success(function (data) {
                        var autocompleteData = $.map(data.computers, function (item, i) {
                            return {
                                label: item.model,
                                value: item.model
                            }
                        });
                        response(autocompleteData);
                    });
                },
                minLength: 2,
                select: function (e, ui) {
                    $rootScope.beginSearch(ui.item.label);
                },
                close: function (e, ui) {
                    $timeout(function () {
                        $("#searchInput").keyup(KeyUpEvent);
                    }, 300);
                },
                open: function (e, ui) {
                    $("#searchInput").unbind("keyup");
                }
            });
           

            $rootScope.beginSearch = function (term) {
                var states = $state.get();
                var homeState;
                for (var i = 0; i < states.length; i++) {
                    if (states[i].name === "home") {
                        var homeState = states[i];
                        break;
                    }
                }
                window.location.hash = "#" + homeState.url.replace(":term", term)
                
            }

            $rootScope.$on('$stateChangeSuccess', function (event, toState, toParams, fromState, fromParams) {
                vm.currentMenuName = toState.menu;
                $rootScope.searchTerm = toParams.term;
            });
        }
    ]);
})();