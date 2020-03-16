import {Component, Inject} from '@angular/core';
import { HttpClient } from '@angular/common/http';
import {KeyValue} from "@angular/common";


@Component({
  selector: 'app-counter-component',
  templateUrl: './pets.component.html'
})
export class PetsComponent {
  public petsModel: KeyValue<string, string[]>;
  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<KeyValue<string, string[]>>(baseUrl + 'pets').subscribe(result => {
      this.petsModel = result;
    }, error => console.error(error));
  }
}

