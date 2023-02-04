#define sf_init
global.sf_cur_font = -1;
global.sf_cur_halign = fa_left;
global.sf_cur_valign = fa_top;
global.sf_cur_color = c_white;
global.sf_cur_alpha = 1;

global.sf_lines = ds_list_create();

#define sf_font_add
///sf_font_add(texture_file_name, glyphs_file_name)
var font, size, f, i;

font = ds_map_create();

f = file_text_open_read(argument1);

size = file_text_read_real(f);
file_text_readln(f);

glyph_count = file_text_read_real(f);
file_text_readln(f);

for (i = 0; i < glyph_count; i += 1) {
    var char, xx, yy, ww, hh, xo, yo, xa, glyph;
    
    char = file_text_read_string(f);
    file_text_readln(f);
    
    xx = file_text_read_real(f);
    file_text_readln(f);
    
    yy = file_text_read_real(f);
    file_text_readln(f);
    
    ww = file_text_read_real(f);
    file_text_readln(f);
    
    hh = file_text_read_real(f);
    file_text_readln(f);
    
    xo = file_text_read_real(f);
    file_text_readln(f);
    
    yo = file_text_read_real(f);
    file_text_readln(f);
    
    xa = file_text_read_real(f);
    file_text_readln(f);
    
    glyph = ds_map_create();
    ds_map_add(glyph, 'x', xx);
    ds_map_add(glyph, 'y', yy);
    ds_map_add(glyph, 'w', ww);
    ds_map_add(glyph, 'h', hh);
    ds_map_add(glyph, 'xo', xo);
    ds_map_add(glyph, 'yo', yo);
    ds_map_add(glyph, 'xa', xa);
    ds_map_add(font, char, glyph);
}
file_text_close(f);

ds_map_add(font, 'size', size); // size is font height
ds_map_add(font, 'spr', sprite_add(argument0, 0, 0, 0, 0, 0));

return font;



#define sf_font_delete
///sf_font_delete(font)

var font;
font = argument0;

var size, key, last, i;
size = ds_map_size(font);
key = ds_map_find_first(font);
last = ds_map_find_last(font);
for (i = 0; i < size; i += 1) {
    if (key == 'size') {
        continue;
    } else if (key == 'spr') {
        sprite_delete(ds_map_find_value(font, key));
    } else {
        ds_map_destroy(ds_map_find_value(font, key));
    }

    if (key != last) {
        key = ds_map_find_next(font, key);
    }
    else break;
}

ds_map_destroy(font);

#define sf_draw_set_halign
///sf_draw_set_halign(halign)
global.sf_cur_halign = argument0;

#define sf_draw_set_valign
///sf_draw_set_valign(valign)
global.sf_cur_valign = argument0;

#define sf_draw_set_color
///sf_draw_set_color(color)
global.sf_cur_color = argument0;

#define sf_draw_set_alpha
///sf_draw_set_alpha(alpha)
global.sf_cur_alpha = argument0;

#define sf_draw_set_font
///sf_draw_set_font(font)
global.sf_cur_font = argument0

#define sf_draw_get_halign
return global.sf_cur_halign;

#define sf_draw_get_valign
return global.sf_cur_valign;

#define sf_draw_get_font
return global.sf_cur_font;

#define sf_draw_text
///sf_draw_text(x, y, text)
var xo, yo, text;
xo = argument0;
yo = argument1;
text = argument2;

ds_list_clear(global.sf_lines);

// split lines to list
var i, char, line, len;
line = '';
len = string_length(text);
for (i = 1; i <= len; i += 1) {
    char = string_char_at(text, i);
    if (char == '#' || char == chr(10)) {
        ds_list_add(global.sf_lines, line);
        line = '';
    } else {
        line += char;
    }
}
ds_list_add(global.sf_lines, line);

// adjust v-align
var total_height, size;
size = ds_map_find_value(global.sf_cur_font, 'size');
total_height = ds_list_size(global.sf_lines) * size;

var cur_x, cur_y;
cur_y = yo;
if (global.sf_cur_valign == fa_middle) cur_y -= total_height / 2;
if (global.sf_cur_valign == fa_bottom) cur_y -= total_height;

// draw lines
var j, line, glyph, spr;
spr = ds_map_find_value(global.sf_cur_font, 'spr');
for (i = 0; i < ds_list_size(global.sf_lines); i += 1) {
    cur_x = xo;
    line = ds_list_find_value(global.sf_lines, i);
    
    // adjust h-align
    if (global.sf_cur_halign != fa_left) {
        // measure line width
        var line_width;
        line_width = 0;
        for (j = 1; j <= string_length(line); j += 1) {
            char = string_char_at(line, j);
            if (!ds_map_exists(global.sf_cur_font, char)) {
                continue;
            }
            line_width += ds_map_find_value(ds_map_find_value(global.sf_cur_font, char), 'xa');
        }
        
        // adjust h-align
        if (global.sf_cur_halign == fa_center) cur_x = xo - line_width / 2;
        if (global.sf_cur_halign == fa_right) cur_x = xo - line_width;
    }
    
    // draw current line
    for (j = 1; j <= string_length(line); j += 1) {
        char = string_char_at(line, j);
        if (!ds_map_exists(global.sf_cur_font, char)) {
            continue;
        }
        glyph = ds_map_find_value(global.sf_cur_font, char);
        draw_sprite_part_ext(spr, 0,
                ds_map_find_value(glyph, 'x'),
                ds_map_find_value(glyph, 'y'),
                ds_map_find_value(glyph, 'w'),
                ds_map_find_value(glyph, 'h'),
                cur_x + ds_map_find_value(glyph, 'xo'), 
                cur_y + ds_map_find_value(glyph, 'yo'),
                1,
                1,
                global.sf_cur_color,
                global.sf_cur_alpha
        )
        cur_x += ds_map_find_value(glyph, 'xa');
    }
    
    cur_y += size;
}


