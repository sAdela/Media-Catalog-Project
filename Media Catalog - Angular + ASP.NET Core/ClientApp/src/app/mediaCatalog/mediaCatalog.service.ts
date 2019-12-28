import { IMediaCatalog } from "./mediaCatalog";
import { Injectable } from "@angular/core";
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})

export class MediaCatalogService {

  private apiUrlGetAll = "http://localhost:49542/api/mediaItems";
  private apiUrlSearch = "http://localhost:49542/api/mediaItems/search";
  paramGenre: string;
  paramCountry: string;
  params: string;
  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
      'Accept': 'application/json'
    })
  };

  constructor(private http: HttpClient) { }

  getMediaItems(): Observable<IMediaCatalog[]> {
    return this.http.get<IMediaCatalog[]>(this.apiUrlGetAll);
  }
  getMediaItemsGenre(genre: string): Observable<IMediaCatalog[]>{

    this.paramGenre = "{" + "\"genre\"" + ":" + "\"" + genre + "\"" + "}";
    console.log(this.paramGenre);
    return this.http.post<IMediaCatalog[]>(this.apiUrlSearch, this.paramGenre, this.httpOptions);
  }

  getMediaItemsCountry(country: string): Observable<IMediaCatalog[]> {

    this.paramCountry = "{" + "\"country\"" + ":" + "\"" + country + "\"" + "}";
    console.log(this.paramCountry);
    return this.http.post<IMediaCatalog[]>(this.apiUrlSearch, this.paramCountry, this.httpOptions);
  }

  getMediaItemsCountryGenre(country: string, genre: string): Observable<IMediaCatalog[]> {
    this.paramCountry = "{" + "\"country\"" + ":" + "\"" + country + "\"" + ",";
    this.paramGenre = "\"genre\"" + ":" + "\"" + genre + "\"" + "}";
    this.params = this.paramCountry + this.paramGenre;
    console.log(this.params);
    return this.http.post<IMediaCatalog[]>(this.apiUrlSearch, this.params, this.httpOptions);
  }

  getSearchQuery(searchQuery: string) {
    searchQuery = "{" + "\"searchQuery\"" + ":" + "\"" + searchQuery + "\"" + "}";
    console.log(searchQuery);
    return this.http.post<IMediaCatalog[]>(this.apiUrlSearch, searchQuery, this.httpOptions);
  }


  titleCase(str): string {

    var splitStr = str.toLowerCase().split(' ');
    for (var i = 0; i < splitStr.length; i++) {
      splitStr[i] = splitStr[i].charAt(0).toUpperCase() + splitStr[i].substring(1);
    }
    return splitStr.join(' ');
  }


}
