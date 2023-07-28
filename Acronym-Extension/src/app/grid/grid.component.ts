import { Component } from '@angular/core';
import { Acronym } from './grid.module';

@Component({
  selector: 'app-grid',
  templateUrl: './grid.component.html',
  styleUrls: ['./grid.component.css']
})
export class GridComponent {
  public gridData: Acronym[] = [
    {
      AcronymID: 1,
      Acronym: "B",
      ExpandedText: "XYZ",
      Type:"User"
    },
    {
      AcronymID: 2,
      Acronym: "Test",
      ExpandedText: "Test123",
      Type:"User"
    },
    {
      AcronymID: 3,
      Acronym: "Y",
      ExpandedText: "Yet",
      Type:"Enterprise"
    },
    {
      AcronymID: 4,
      Acronym: "Test1",
      ExpandedText: "Test65",
      Type:"User"
    }
  ]
}
