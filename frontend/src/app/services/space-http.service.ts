import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { StarshipQueryResponseDto } from '../dtos/responses/starship-query-response.dto';
import { StarshipQueryRequestDto } from '../dtos/requests/starship-query-request.dto';

@Injectable()
export class SpaceHttpService {

  apiAddress = 'https://localhost:44374/v1/space/';
  headers = new HttpHeaders({ 'Content-Type': 'application/json; charset=utf-8' });
  options = { headers: this.headers };

  constructor(private http: HttpClient) {
  }

  getStarships(request: StarshipQueryRequestDto) {
    return this.http.post(this.apiAddress + 'get-starships', request, this.options) as Observable<StarshipQueryResponseDto>;
  }
}
