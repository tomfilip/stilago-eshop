(function() {
    var controllerId = 'app.views.home';
    var app = angular.module('app');
    app.controller(controllerId, [
        '$scope', '$stateParams', '$state', 'abp.services.app.search', function ($scope, $stateParams, $state, searchService) {
            var vm = this;
            
            $scope.searchData = [];
            $scope.brandId = null;
            $scope.sortBy = 0;
            $scope.sortDirection = 0;

            $scope.search = function () {
                searchService
                    .search({
                        searchTerm: $stateParams.term,
                        brandId: $scope.brandId,
                        sortBy: $scope.sortBy,
                        sortDirection: $scope.sortDirection
                    })
                    .success(function (data) {
                        $scope.searchData = data.computers;
                    });
            }
            $scope.search();

            $scope.addToShoppingCart = function () {
                toastr.info("This is not yet implemented");
            }

            $("#sortDirection").change(function () {
                $scope.sortDirection = $("#sortDirection").find("option:selected").val();
                $scope.search();
            });

            $("#sortByColumn").change(function () {
                $scope.sortBy = $("#sortByColumn").find("option:selected").val();
                $scope.search();
            });
        }
    ]);

    app.directive("brandsFilter", ['abp.services.app.search', function (searchService) {
        return {
            restrict: 'E',
            transclude: true,
            template: '<select class="select"></select>',
            link: function ($scope, element) {
                var html = "<option value='null'>All Brands</option>";

                searchService
                    .getAllBrands({})
                    .success(function (data) {
                        for (var i = 0; i < data.brands.length; i++) {
                            html += "<option value='" + data.brands[i].id + "'>" + data.brands[i].name + "</option>";
                        }
                        element.html("<select class='select'>" + html + "</select>");

                        element.change(function () {
                            var brandId = element.find("option:selected").val();
                            $scope.brandId = brandId;
                            $scope.search();
                        });
                    });
            }
        };
    }]);
})();