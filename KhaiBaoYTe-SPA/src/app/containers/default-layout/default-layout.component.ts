import {Component, OnInit} from '@angular/core';
import { navItems } from '../../_nav';

@Component({
  selector: 'app-dashboard',
  templateUrl: './default-layout.component.html'
})
export class DefaultLayoutComponent{
  public sidebarMinimized = false;
  public navItems = navItems;
  toggleMinimize(e) {
    this.sidebarMinimized = e;
  }
  ngAfterViewInit() {
    let elements = document.getElementsByClassName("navbar-toggler-icon");
    console.log(elements); 
    if(elements.length > 0) {
      elements[3].parentElement.remove();
      elements[2].parentElement.remove();
      
    }
  }
}
