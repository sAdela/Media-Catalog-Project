"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = require("@angular/core");
var MediaCatalogComponent = /** @class */ (function () {
    function MediaCatalogComponent(mediaItemsService) {
        this.mediaItemsService = mediaItemsService;
        this.genres = ["All Genres", "Rock", "Pop"];
        this.countries = ["All Countries", "BiH", "Croatia", "Serbia"];
        this.selectedGenre = "All Genres";
        this.selectedCountry = "All Countries";
    }
    MediaCatalogComponent.prototype.getValues = function () {
        var _this = this;
        if (this.selectedGenre != null && this.selectedCountry != null && this.selectedGenre != "All Genres"
            && this.selectedCountry != "All Countries") {
            this.mediaItemsService.getMediaItemsCountryGenre(this.selectedCountry, this.selectedGenre)
                .subscribe({
                next: function (mediaItems) { return _this.mediaItems = mediaItems; }
            });
        }
        else if ((this.selectedGenre != null && this.selectedGenre != "All Genres") && this.selectedCountry == null) {
            this.mediaItemsService.getMediaItemsGenre(this.selectedGenre).subscribe({
                next: function (mediaItems) { return _this.mediaItems = mediaItems; }
            });
        }
        else if (this.selectedGenre == null && (this.selectedCountry != null && this.selectedCountry != "All Countries")) {
            this.mediaItemsService.getMediaItemsCountry(this.selectedCountry).subscribe({
                next: function (mediaItems) { return _this.mediaItems = mediaItems; }
            });
        }
        else if ((this.selectedGenre != null && this.selectedGenre != "All Genres") && this.selectedCountry == "All Countries") {
            this.mediaItemsService.getMediaItemsGenre(this.selectedGenre).subscribe({
                next: function (mediaItems) { return _this.mediaItems = mediaItems; }
            });
        }
        else if ((this.selectedGenre == "All Genres") && (this.selectedCountry != null && this.selectedCountry != "All Countries")) {
            this.mediaItemsService.getMediaItemsCountry(this.selectedCountry).subscribe({
                next: function (mediaItems) { return _this.mediaItems = mediaItems; }
            });
        }
        else if (this.selectedGenre == "All Genres" && this.selectedCountry == "All Countries") {
            this.mediaItemsService.getMediaItems().subscribe({
                next: function (mediaItems) { return _this.mediaItems = mediaItems; }
            });
        }
    };
    MediaCatalogComponent.prototype.getSearchQueryItems = function (search) {
        var _this = this;
        //search = this.mediaItemsService.titleCase(search);
        search = search.toLowerCase();
        this.mediaItemsService.getSearchQuery(search).subscribe({
            next: function (mediaItems) { return _this.mediaItems = mediaItems; }
        });
    };
    MediaCatalogComponent.prototype.ngOnInit = function () {
        var _this = this;
        this.mediaItemsService.getMediaItems().subscribe({
            next: function (mediaItems) { return _this.mediaItems = mediaItems; }
        });
    };
    MediaCatalogComponent = __decorate([
        core_1.Component({
            selector: 'mediaCatalog',
            templateUrl: './mediaCatalog.component.html',
            styleUrls: ['./mediaCatalog.component.css']
        })
    ], MediaCatalogComponent);
    return MediaCatalogComponent;
}());
exports.MediaCatalogComponent = MediaCatalogComponent;
//# sourceMappingURL=mediaCatalog.component.js.map