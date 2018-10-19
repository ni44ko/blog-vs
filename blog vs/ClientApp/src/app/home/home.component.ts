import { Component, OnInit } from "@angular/core";
import { BlogService } from "../services/blog.service";

@Component({
  selector: "app-home",
  templateUrl: "./home.component.html",
  styleUrls: ["./home.component.scss"]
})
export class HomeComponent implements OnInit {
  postlist: string;
  constructor(private blogService: BlogService) {}

  ngOnInit() {
    this.loadPosts();
  }

  loadPosts() {
    this.blogService.getPosts().subscribe(
        data => {
          console.log("data: " + JSON.stringify(data));
          this.postlist =  JSON.stringify(data);
        };
      ,
      error => {
        console.log("error collection: " + error);
      }
    );
  }
}
