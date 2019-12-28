"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = require("@angular/core");
var http_1 = require("@angular/common/http");
var MediaCatalogService = /** @class */ (function () {
    function MediaCatalogService(http) {
        this.http = http;
        this.apiUrlGetAll = "http://localhost:49542/api/mediaItems";
        this.apiUrlSearch = "http://localhost:49542/api/mediaItems/search";
        this.httpOptions = {
            headers: new http_1.HttpHeaders({
                'Content-Type': 'application/json',
                'Accept': 'application/json'
            })
        };
    }
    MediaCatalogService.prototype.getMediaItems = function () {
        return this.http.get(this.apiUrlGetAll);
    };
    MediaCatalogService.prototype.getMediaItemsGenre = function (genre) {
        this.paramGenre = "{" + "\"genre\"" + ":" + "\"" + genre + "\"" + "}";
        console.log(this.paramGenre);
        return this.http.post(this.apiUrlSearch, this.paramGenre, this.httpOptions);
    };
    MediaCatalogService.prototype.getMediaItemsCountry = function (country) {
        this.paramCountry = "{" + "\"country\"" + ":" + "\"" + country + "\"" + "}";
        console.log(this.paramCountry);
        return this.http.post(this.apiUrlSearch, this.paramCountry, this.httpOptions);
    };
    MediaCatalogService.prototype.getMediaItemsCountryGenre = function (country, genre) {
        this.paramCountry = "{" + "\"country\"" + ":" + "\"" + country + "\"" + ",";
        this.paramGenre = "\"genre\"" + ":" + "\"" + genre + "\"" + "}";
        this.params = this.paramCountry + this.paramGenre;
        console.log(this.params);
        return this.http.post(this.apiUrlSearch, this.params, this.httpOptions);
    };
    MediaCatalogService.prototype.getSearchQuery = function (searchQuery) {
        searchQuery = "{" + "\"searchQuery\"" + ":" + "\"" + searchQuery + "\"" + "}";
        console.log(searchQuery);
        return this.http.post(this.apiUrlSearch, searchQuery, this.httpOptions);
    };
    MediaCatalogService.prototype.titleCase = function (str) {
        var splitStr = str.toLowerCase().split(' ');
        for (var i = 0; i < splitStr.length; i++) {
            splitStr[i] = splitStr[i].charAt(0).toUpperCase() + splitStr[i].substring(1);
        }
        return splitStr.join(' ');
    };
    MediaCatalogService = __decorate([
        core_1.Injectable({
            providedIn: 'root'
        })
    ], MediaCatalogService);
    return MediaCatalogService;
}());
exports.MediaCatalogService = MediaCatalogService;
//# sourceMappingURL=mediaCatalog.service.js.map