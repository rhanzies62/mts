import { Component, OnInit } from '@angular/core';
declare var jquery: any;
declare var $: any;
@Component({
    selector: 'dashboard',
    templateUrl: './Dashboard.Component.html'
})
export class DashboardComponent implements OnInit {
    ngOnInit(): void {
        $('.profile').mouseenter(function () {
            $('#profileDropdown').show().css('opacity', '1');
        }).mouseleave(function () {
            $('#profileDropdown').hide().css('opacity', '1');
        });
    }
    constructor() {
        
    }
}
