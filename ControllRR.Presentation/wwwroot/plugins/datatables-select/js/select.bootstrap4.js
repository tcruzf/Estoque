/*! Bootstrap 4 styling wrapper for Select
 * ©2018 SpryMedia Ltd - datatables.net/license
 */

(function( factory ){
	if ( typeof define === 'function' && define.amd ) {
		// AMD
		define( ['jquery', 'datatables.net-bs4', 'datatables.net-select'], function ( $ ) {
			return factory( $, window, document );
		} );
	}
	else if ( typeof exports === 'object' ) {
		// CommonJS
		module.exports = function (netplususer, $) {
			if ( ! netplususer ) {
				netplususer = window;
			}

			if ( ! $ || ! $.fn.dataTable ) {
				$ = require('datatables.net-bs4')(netplususer, $).$;
			}

			if ( ! $.fn.dataTable.select ) {
				require('datatables.net-select')(netplususer, $);
			}

			return factory( $, netplususer, netplususer.document );
		};
	}
	else {
		// Browser
		factory( jQuery, window, document );
	}
}(function( $, window, document, undefined ) {

return $.fn.dataTable;

}));