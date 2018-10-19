import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Post } from '../models/Post';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class BlogService {
  API_URL: string = "https://localhost:44397/api/blog/GetPosts";
  constructor(private httpClient: HttpClient) {}
  
  getPosts(): Observable<Post[]>{
    return this.httpClient.get<Post[]>(this.API_URL);
  }
  // create(u: User): Observable<ValidationAnnotation[]> {
  //   return this.httpClient.post<ValidationAnnotation[]>(this.API_URL, u);
  // }
}
