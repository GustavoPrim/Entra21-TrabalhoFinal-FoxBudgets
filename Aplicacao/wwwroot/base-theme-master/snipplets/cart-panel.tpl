<div class="js-ajax-cart-list cart-row">
    {# Cart panel items #}
    {% if cart.items %}
      {% for item in cart.items %}
        {% include "snipplets/cart-item-ajax.tpl" %}
      {% endfor %}
    {% endif %}
</div>
<div class="js-empty-ajax-cart cart-row" {% if cart.items_count > 0 %}style="display:none;"{% endif %}>
     {# Carrinho Vazio #}
    <div class="alert alert-info">{{ "O carrinho de compras está vazio." }}</div>
</div>
<div id="error-ajax-stock" style="display: none;">
    <div class="alert alert-warning">
         {{ "Erro. Não temos mais estoque desse produto." }}<a href="{{ store.products_url }}" class="btn-link ml-1">{{ "Ver mais produtos" }}</a>
    </div>
</div>
<div class="cart-row">
    {% include "snipplets/cart-totals.tpl" %}
</div>