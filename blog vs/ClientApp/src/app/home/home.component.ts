import { Component, OnInit } from "@angular/core";
import { BlogService } from "../services/blog.service";
import { Post } from "../models/Post";
import { Subscriber } from "rxjs";
import { Category } from "../models/Category";

@Component({
  selector: "app-home",
  templateUrl: "./home.component.html",
  styleUrls: ["./home.component.scss"]
})
export class HomeComponent implements OnInit {
  postlist: Post[];
  latestpostlist: Post[];
  categories: Category[];
  constructor(private blogService: BlogService) {}

  ngOnInit() {
    this.loadPosts();
    this.loadLatestPosts();
    this.loadCategories();
  }

  loadPosts() {
    this.blogService.getPosts().subscribe(
      data => {
        this.postlist = (data);
        console.log('data: ' + JSON.stringify(this.postlist));
      },
      error => {
        console.log('error in loadPosts()' + error);
      }
    );
  }

  loadLatestPosts() {
    this.blogService.getLatestPosts().subscribe(
      data => {
        this.latestpostlist = (data);
      },
      error => {
        console.log('error in loadLatestPosts()');
      }
    );
  }

  loadCategories() {
    this.blogService.getCategories().subscribe(
      data => {
        this.categories = (data)
      },
      error => {
        console.log('error in loadCategories()');
      }
    )
  }
}
