import { Directive, HostListener } from '@angular/core';

@Directive({
  selector: '[appNationalIdInputOnly]'
})
export class NationalIdInputOnlyDirective {

  @HostListener('input', ['$event']) onInput(event: Event): void {
    const input = event.target as HTMLInputElement;
    const numericPattern = /^[0-9]*$/;

    // Check if the input value contains non-numeric characters
    if (!numericPattern.test(input.value)) {
      input.value = input.value.replace(/[^0-9]/g, '');
    }

    // Limit the input to 14 digits
    const maxLength = 14;
    if (input.value.length > maxLength) {
      input.value = input.value.slice(0, maxLength);
    }
  }

  constructor() { }

}
