#define sf_init
global.sf_cur_font = -1;
global.sf_cur_halign = fa_left;
global.sf_cur_valign = fa_top;
global.sf_cur_color = c_white;
global.sf_cur_alpha = 1;

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

ds_map_add(font, 'size', size); // size is font **height**
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
///sf_draw_get_halign()
return global.sf_cur_halign;

#define sf_draw_get_valign
///sf_draw_get_valign()
return global.sf_cur_valign;

#define sf_draw_get_font
///sf_draw_get_font()
return global.sf_cur_font;

#define sf_draw_text
///sf_draw_text(x, y, text)
_sf_draw_text(argument2, argument0, argument1, -1, -1, 0, 1, 1);

#define sf_draw_text_transformed
///sf_draw_text_transformed(x, y, text, xscale, yscale, angle)
_sf_draw_text(argument2, argument0, argument1, -1, -1, argument5, argument3, argument4);

#define sf_draw_text_ext
///sf_draw_text_ext(x, y, text, sep, w)
_sf_draw_text(argument2, argument0, argument1, argument3, argument4, 0, 1, 1);

#define sf_draw_text_ext_transformed
///sf_draw_text_ext_transformed(x, y, text, sep, w, xscale, yscale, angle)
_sf_draw_text(argument2, argument0, argument1, argument3, argument4, argument7, argument5, argument6);

#define sf_string_width
///sf_string_width(str)
return _sf_text_width(argument0);

#define sf_string_width_ext
///sf_string_width_ext(str, sep, w)

var str, sep, w;
str = argument0;
sep = argument1;
w = argument2;

var sl, result;
sl = ds_list_create();
_sf_split_text(sl, str, w);
if (sep < 0) {
    sep = _sf_get_font_size();
}

result = 0;
var i;
for (i = 0; i < ds_list_size(sl); i += 1) {
    var width;
    width = _sf_text_width(ds_list_find_value(sl, i));
    if (result < width) {
        result = width;
    }
}

ds_list_destroy(sl);

return result;

#define sf_string_height
///sf_string_height(str)

var str, i, len, newlines;
str = argument0;

newlines = 1;

len = string_length(str);
for (i = 0; i < len; i += 1) {
    if (string_char_at(str, i + 1) == chr(10) || string_char_at(str, i + 1) == '#') {
        newlines += 1;
    }
} 

return _sf_get_font_size() * newlines;


#define sf_string_height_ext
///sf_string_height_ext(str, sep, w)

var str, sep, w;
str = argument0;
sep = argument1;
w = argument2;

var sl, result;
sl = ds_list_create();
_sf_split_text(sl, str, w);
if (sep < 0) {
    sep = _sf_get_font_size();
}

result = ds_list_size(sl) * sep;

ds_list_destroy(sl);

return result;

#define _sf_split_text
///_sf_split_text(list, str, linewidth)
///Convert text to a list.

var sl, str, linewidth;
sl = argument0;
str = argument1;
linewidth = argument2;

if (linewidth < 0) {
    linewidth = 10000000;
}

var st, ed, len;
st = 0;
ed = 0;
len = string_length(str);
while (st < len) {
    var total;
    total = 0;
    
    // if width < 0 (i.e. no wrapping required), then we DON'T strip spaces from the start... we just copy it!  (sounds wrong.. but its what they do...)
    if (linewidth == 10000000) {
        while (ed < len && (string_char_at(str, ed + 1) != chr(10) && string_char_at(str, ed + 1) != '#')) {
            ed += 1;
        }
        ds_list_add(sl, string_copy(str, st + 1, ed - st)); // add into our list...
    } else {
        // skip leading whitespace
        while (ed < len) {
            if (string_char_at(str, ed + 1) != ' ') {
                break;
            }
            ed += 1;
        }
        st = ed;

        var glyph;
        
        // loop through string and get the number of chars that will fit in the line.
        while (ed < len && total < linewidth) {
            if (string_char_at(str, ed + 1) == chr(10) || string_char_at(str, ed + 1) == '#') {
                break;
            } 
            glyph = _sf_get_glyph(string_char_at(str, ed + 1));
            total += _sf_glyph_get_info(glyph, 'xa');
            ed += 1;
        }

        // if we shot past the end, then move back a bit until we fit.
        if (total > linewidth) {
            ed -= 1;
            glyph = _sf_get_glyph(string_char_at(str, ed + 1));
            total -= _sf_glyph_get_info(glyph, 'xa');
        }

        // END of line
        if (string_char_at(str, ed + 1) == chr(10) || string_char_at(str, ed + 1) == '#') {
            ds_list_add(sl, string_copy(str, st + 1, ed - st));
        } else {
            // NOT a new line, but we didn't move on... fatel error. Probably a single char doesn't even fit!
            if (ed == st) {
                exit;
            }
            
            // If we don't END on a "space", OR if the next character isn't a space AS WELL. 
            // then backtrack to the start of the last "word"
            if (ed != len) {
                if ((string_char_at(str, ed + 1) != ' ') || 
                    (string_char_at(str, ed + 1) != ' ' && string_char_at(str, ed + 2) != ' ')) {
                    while (ed > st) {
                        ed -= 1;
                        if (string_char_at(str, ed + 1) == ' ') {
                            break;
                        }
                    }
                }
            }
            
            if (ed > st) {
                while (string_char_at(str, ed) == ' ') {
                    ed -= 1;
                }
            } else if (ed == st) {
                while (string_char_at(str, ed + 1) != ' ' && ed < len) {
                    ed += 1;
                }
            }

            ds_list_add(sl, string_copy(str, st + 1, ed - st));
        }
    }
    
    ed += 1;
    st = ed;
}

#define _sf_draw_text
///_sf_draw_text(str, x, y, linesep, linewidth, angle, xscale, yscale)
///Draw multiline text.

var str, xx, yy, linesep, linewidth, angle, xscale, yscale;
str = argument0;
xx = argument1;
yy = argument2;
linesep = argument3;
linewidth = argument4;
angle = argument5;
xscale = argument6;
yscale = argument7;

var sl;
sl = ds_list_create();

_sf_split_text(sl, str, linewidth);

var ang, ss, cc;
ang = degtorad(angle);
ss = sin(ang);
cc = cos(ang);

var font_size;
font_size = _sf_get_font_size();

if (linesep <= 0) {
    linesep = font_size;
}

var xsep, ysep;
xsep = ss * xscale * linesep;
ysep = cc * yscale * linesep;

if (global.sf_cur_valign == fa_middle) {
    yy -= (ds_list_size(sl) * ysep) / 2;
    xx -= (ds_list_size(sl) * xsep) / 2;
}
if (global.sf_cur_valign == fa_bottom) {
    yy -= (ds_list_size(sl) * ysep);
    xx -= (ds_list_size(sl) * xsep);
}

// draw text
var i, xoff, yoff;
for (i = 0; i < ds_list_size(sl); i += 1) {
    xoff = 0;
    yoff = 0;
    
    var line;
    line = ds_list_find_value(sl, i);
    
    if (global.sf_cur_halign == fa_center) {
        xoff = -(xscale * _sf_text_width(line) / 2); 
    }
    if (global.sf_cur_halign == fa_right) {
        xoff = -(xscale * _sf_text_width(line));
    }
    
    var dx, dy;
    dx = xx + cc * xoff + ss * yoff;
    dy = yy - ss * xoff + cc * yoff;
    
    _sf_draw_string_line(dx, dy, line, xscale, yscale, angle, ss, cc);
    
    xx += xsep;
    yy += ysep;
}

ds_list_destroy(sl);

#define _sf_draw_string_line
                                                                                                                                                                             ///_sf_draw_string_line(x, y, str, xscale, yscale, angle, ss, cc)
///Draw a line of text.

var xx, yy, str, xscale ,yscale, angle, ss, cc;
xx = argument0;
yy = argument1;
str = argument2;
xscale = argument3;
yscale = argument4;
angle = argument5;
ss = argument6;
cc = argument7;

var len, i;
len = string_length(str);

for (i = 0; i < len; i += 1) {
    var ch;
    ch = string_char_at(str, i + 1);
    
    var glyph;
    glyph = _sf_get_glyph(ch);
    
    var xo, yo, xa;
    xo = _sf_glyph_get_info(glyph, 'xo');
    yo = _sf_glyph_get_info(glyph, 'yo');
    xa = _sf_glyph_get_info(glyph, 'xa');

    draw_sprite_general(_sf_get_sprite(), 0, 
        _sf_glyph_get_info(glyph, 'x'),
        _sf_glyph_get_info(glyph, 'y'),
        _sf_glyph_get_info(glyph, 'w'),
        _sf_glyph_get_info(glyph, 'h'),
        xx + xo * xscale * cc + yo * yscale * ss,
        yy + xo * xscale * -ss + yo * yscale * cc,
        xscale, yscale, angle,
        global.sf_cur_color, global.sf_cur_color, global.sf_cur_color, global.sf_cur_color,
        global.sf_cur_alpha  
    );  
    
    xx += cc * xa * xscale;
    yy -= ss * xa * xscale;
}

#define _sf_text_width
///_sf_text_width(str)
///Measure the width of multiline text.

var i, len, glyph, result;
len = string_length(argument0);
result = 0;
for (i = 0; i < len; i += 1) {
    glyph = _sf_get_glyph(string_char_at(argument0, i + 1));
    result += _sf_glyph_get_info(glyph, 'xa');
} 

return result;

#define _sf_get_glyph
///_sf_get_glyph(char)
///Get the glyph map of the specified character in the current font.

if (ds_map_exists(global.sf_cur_font, argument0)) {
    return ds_map_find_value(global.sf_cur_font, argument0);
} else {
    return ds_map_find_value(global.sf_cur_font, ' ');
}


#define _sf_glyph_get_info
///_sf_glyph_get_info(glyph, property)
///Get an property of the specified glyph.
///
/// Property:
/// "x"
/// "y"
/// "w"
/// "h"
/// "xo"
/// "yo"
/// "xa"

return ds_map_find_value(argument0, argument1);

#define _sf_get_sprite
///_sf_get_sprite()
///Get the sprite page of the current font.

return ds_map_find_value(global.sf_cur_font, 'spr');

#define _sf_get_font_size
///_sf_get_font_size()
///Get the size (height) of the current font.

return ds_map_find_value(global.sf_cur_font, 'size');

