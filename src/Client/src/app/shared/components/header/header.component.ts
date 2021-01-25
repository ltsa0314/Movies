import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss'],
})
export class HeaderComponent implements OnInit {
  constructor(private router: Router) {}

  ngOnInit(): void {}
  onHome() {
    this.router.navigateByUrl('/home');
  }
  searchMovie(text: string) {
    text = text.trim();
    if (text.length === 0) {
      return;
    }
    this.router.navigate(['/search', text]);
  }
}
