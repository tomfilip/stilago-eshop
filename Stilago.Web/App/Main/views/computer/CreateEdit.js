(function() {
    var controllerId = 'app.views.computerCreateEdit';
    angular.module('app').controller(controllerId, [
        '$scope', '$stateParams', '$state', 'abp.services.app.computer', function ($scope, $stateParams, $state, computerService) {
            var vm = this;

            $scope.id = $stateParams.id;

            if ($stateParams.id == undefined) {
                $scope.headerMessage = "Add new computer";
            }
            else {
                $scope.headerMessage = "Edit computer";
            }

            $scope.form = {};

            computerService
                .get({ id: ($stateParams.id == undefined ? null : $stateParams.id) })
                .success(function (data) {
                    $scope.form = data.computer;
                });

            $scope.delete = function () {
                if ($scope.id != undefined) {
                    computerService
                        .delete({ id: $scope.id })
                        .success(function () {
                            window.location.hash = "#/search/";
                        });
                }
            }

            $scope.save = function () {
                if (!$scope.computerForm.$valid) {
                    toastr.error("The form is invalid. Please check your values.");
                }
                else {
                    if ($stateParams.id == undefined) {
                        computerService
                          .create({ computer: $scope.form })
                          .success(function (data) {
                              var states = $state.get();
                              var preview;
                              for (var i = 0; i < states.length; i++) {
                                  if (states[i].name == "computerPreview") {
                                      preview = states[i];
                                      break;
                                  }
                              }

                              window.location.hash = "#" + preview.url.replace(":id", data.id);
                        });
                    }
                    else {
                        computerService
                          .update({ computer: $scope.form })
                          .success(function (data) {
                              var states = $state.get();
                              var preview;
                              for (var i = 0; i < states.length; i++) {
                                  if (states[i].name == "computerPreview") {
                                      preview = states[i];
                                      break;
                                  }
                              }

                              window.location.hash = "#" + preview.url.replace(":id", data.id);
                          });
                    }
                   
                }
            }
        }
    ]);
})();