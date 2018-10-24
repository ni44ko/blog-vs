import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Post } from '../models/Post';
import { Observable } from 'rxjs';
import { Category } from '../models/Category';

@Injectable({
  providedIn: 'root'
})
export class BlogService {
  API_URL: string = 'https://localhost:44397/api/blog/';
  constructor(private httpClient: HttpClient) {}
  
  getPosts(): Observable<Post[]>{
    return this.httpClient.get<Post[]>(this.API_URL + 'GetPosts');
  }
  getLatestPosts(): Observable<Post[]>{
    return this.httpClient.get<Post[]>(this.API_URL + 'GetLatestPosts');
  }
  getCategories(): Observable<Category[]>{
return this.httpClient.get<Category[]>(this.API_URL + 'GetCategories')
  }
  // create(u: User): Observable<ValidationAnnotation[]> {
  //   return this.httpClient.post<ValidationAnnotation[]>(this.API_URL, u);
  // }
}
