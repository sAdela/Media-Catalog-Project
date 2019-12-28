import { Component } from '@angular/core';
import { IMediaCatalog } from './mediaCatalog';
import { MediaCatalogService } from './mediaCatalog.service';

@Component({
  selector: 'mediaCatalog',
  templateUrl: './mediaCatalog.component.html',
  styleUrls: ['./mediaCatalog.component.css'] 
})


export class MediaCatalogComponent {
  mediaItems: IMediaCatalog[];
  genres: string[] = ["All Genres", "Rock", "Pop"];
  countries: string[] = ["All Countries", "BiH", "Croatia", "Serbia"];
  selectedGenre: string = "All Genres";
  selectedCountry: string = "All Countries";
  searchQuery: string;

  constructor(private mediaItemsService: MediaCatalogService) {
  }

  getValues(): void {

    if (this.selectedGenre != null && this.selectedCountry != null && this.selectedGenre != "All Genres"
      && this.selectedCountry != "All Countries") {
      this.mediaItemsService.getMediaItemsCountryGenre(this.selectedCountry, this.selectedGenre)
        .subscribe({
          next: mediaItems => this.mediaItems = mediaItems
        })
    }
    else if ((this.selectedGenre != null && this.selectedGenre != "All Genres") && this.selectedCountry == null) {
      this.mediaItemsService.getMediaItemsGenre(this.selectedGenre).subscribe({
        next: mediaItems => this.mediaItems = mediaItems
      })
    }
    else if (this.selectedGenre == null && (this.selectedCountry != null && this.selectedCountry != "All Countries")) {
      this.mediaItemsService.getMediaItemsCountry(this.selectedCountry).subscribe({
        next: mediaItems => this.mediaItems = mediaItems
      });
    }
    else if ((this.selectedGenre != null && this.selectedGenre != "All Genres") && this.selectedCountry == "All Countries") {
      this.mediaItemsService.getMediaItemsGenre(this.selectedGenre).subscribe({
        next: mediaItems => this.mediaItems = mediaItems
      })
    }
    else if ((this.selectedGenre == "All Genres") && (this.selectedCountry != null && this.selectedCountry != "All Countries")) {
      this.mediaItemsService.getMediaItemsCountry(this.selectedCountry).subscribe({
        next: mediaItems => this.mediaItems = mediaItems
      });
    }
    else if (this.selectedGenre == "All Genres" && this.selectedCountry == "All Countries") {
      this.mediaItemsService.getMediaItems().subscribe({
        next: mediaItems => this.mediaItems = mediaItems
      });
    }
  }

  getSearchQueryItems(search: string): void {

    //search = this.mediaItemsService.titleCase(search);
    search = search.toLowerCase();

    this.mediaItemsService.getSearchQuery(search).subscribe({
      next: mediaItems => this.mediaItems = mediaItems
    });

  }

  ngOnInit(): void {
    this.mediaItemsService.getMediaItems().subscribe({
       next: mediaItems => this.mediaItems = mediaItems
    });

  }

}
