import { Component, OnInit } from '@angular/core';
import {  ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-thongbao',
  templateUrl: './thongbao.component.html',
  styleUrls: ['./thongbao.component.css']
})
export class ThongbaoComponent implements OnInit {

  constructor(private router: Router, private route: ActivatedRoute) { }
  id: string;
  ngOnInit() {
    this.id = this.route.snapshot.paramMap.get('id');
  }

  back() {
    this.router.navigate(["/khaibao"]);
  }

}
