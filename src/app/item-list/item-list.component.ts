import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-item-list',
  templateUrl: './item-list.component.html',
  styleUrls: ['./item-list.component.scss']
})
export class ItemListComponent implements OnInit {

  postedContent = '{\"ops\":[{\"insert\":\"hello\"},{\"attributes\":{\"list\":\"ordered\"},\"insert\":\"\\n\"},{\"insert\":\"world\"},{\"attributes\":{\"list\":\"ordered\"},\"insert\":\"\\n\"}]}';
  arrayOne(n: number): any[] {
    return Array(n);
  }

  constructor() { }

  ngOnInit(): void {
  }

}
